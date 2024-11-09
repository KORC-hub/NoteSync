using AutoMapper;
using Azure;
using BusinessLogic.core.UseCases;
using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.UoW;
using DataAccess.SqlServer.Models;
using DomainModel;
using DTOs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Formats.Asn1;

namespace BusinessLogic.core.Service
{
    public class FolderService : IFolderUseCases
    {
        private readonly IRepositoriesManager _repositoriesManager;
        private readonly IMapper _mapper;
        private IFolder _folder;
        private ITag _tag;
        private IFolderTag _folderTag;

        public FolderService(IRepositoriesManager repositoriesManager, IMapper mapper, IFolder folder, ITag tag, IFolderTag folderTag)
        {
            _repositoriesManager = repositoriesManager;
            _mapper = mapper;
            _folder = folder;
            _tag = tag;
            _folderTag = folderTag;
        }
        public async Task<List<FolderDto>> GetAllFoldersAsync(int UserId)
        {
            try
            {
                List<IFolder> foldersFromDataBase = await _repositoriesManager.Folders.GetAllAsync(UserId);
                List<FolderDto> folders = new List<FolderDto>();
                FolderDomainModel folderDomainModel = new FolderDomainModel();

                foreach (IFolder folder in foldersFromDataBase) 
                {
                    folderDomainModel.FolderId = folder.FolderId;
                    folderDomainModel.FolderName = folder.FolderName;
                    folderDomainModel.CreatedAt = folder.CreatedAt;
                    folderDomainModel.LastModifiedAt = folder.LastModifiedDate;
                    folderDomainModel.UserId = folder.UserId;

                    folders.Add(_mapper.Map<FolderDto>(folderDomainModel));   
                }

                List<TagDto> tags = await GetAllTagsAsync(UserId);

                foreach (FolderDto folder in folders)
                {
                    List<int> folderTagsId = await _repositoriesManager.FolderTags.GetAllTagIdByFolderAsync(folder.FolderId);

                    foreach (int tagId in folderTagsId)
                    {
                        folder.Tags.Add(tags.Find(tag => tag.TagId == tagId.ToString()));
                    }
                }

                return folders;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TagDto>> GetAllTagsAsync(int UserId)
        {
            try
            {
                List<ITag> tagsFromDatabase = await _repositoriesManager.Tags.GetAllAsync(UserId);
                List<TagDto> tags = new List<TagDto>();
                TagDomainModel tagDomainModel = new TagDomainModel();

                foreach (ITag tag in tagsFromDatabase)
                {
                    tagDomainModel.TagId = tag.TagId;
                    tagDomainModel.TagContent = tag.TagContent;
                    tagDomainModel.Color = tag.Color;
                    tagDomainModel.UserId = tag.UserId;

                    tags.Add(_mapper.Map<TagDto>(tagDomainModel));
                }

                return tags;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CreateFolder(FolderDto folder, List<TagDto>? tags)
        {
            FolderDomainModel folderDomainModel = _mapper.Map<FolderDomainModel>(folder);
            List<int> newTagsId = new List<int>();
            List<int> existingTagsId = new List<int>();

            try 
            {

                _folder.FolderName = folderDomainModel.FolderName;
                _folder.UserId = folderDomainModel.UserId;

                folderDomainModel.FolderId =  await _repositoriesManager.Folders.CreateAsync(_folder);

                if (tags.Count != 0)
                {
                    foreach (var tag in tags)
                    {
                        if (tag.Type == "new")
                        {
                            _tag.TagId = 0;
                            _tag.UserId = folder.UserId;
                            _tag.TagContent = tag.TagContent;
                            _tag.Color = tag.Color;
                            _tag.TagId = await _repositoriesManager.Tags.CreateAsync(_tag);
                            newTagsId.Add(_tag.TagId);

                        }
                        else if (tag.Type == "existing")
                        {
                            existingTagsId.Add(Convert.ToInt32(tag.TagId));
                        }
                    }

                    List<int> tagsId = newTagsId.Concat(existingTagsId).ToList();

                    foreach (int id in tagsId)
                    {
                        _folderTag.FolderId = folderDomainModel.FolderId;
                        _folderTag.TagId = id;
                        int result = await _repositoriesManager.FolderTags.CreateAsync(_folderTag);
                    }

                }

                await _repositoriesManager.CommitAsync();

                return folderDomainModel.FolderId;
            }
            catch (Exception ex) 
            {

                if (folderDomainModel.FolderId != 0) 
                {
                    await _repositoriesManager.Folders.DeleteAsync(folderDomainModel.FolderId);
                }

                if (newTagsId.Count != 0) 
                {
                    foreach (int id in newTagsId) 
                    { 
                        await _repositoriesManager.Tags.DeleteAsync(id);
                    }
                }

                throw new Exception(ex.Message);
            }

        }

        public async Task UpdateFolder(FolderDto folder, List<TagDto>? tags)
        {
            FolderDomainModel folderDomainModel = _mapper.Map<FolderDomainModel>(folder);
            List<int> newTagsId = new List<int>();
            try
            {
                _folder = await _repositoriesManager.Folders.GetByIdAsync(folderDomainModel.FolderId);
                List<int> tagIdsFromFolder = await _repositoriesManager.FolderTags.GetAllTagIdByFolderAsync(folderDomainModel.FolderId);
                List<int[]> FolderTagIds = await _repositoriesManager.FolderTags.GetAllByFolderAsync(folderDomainModel.FolderId);
                List<int> deleteTags = new List<int>();
                List<int> addTags = new List<int>();

                if (tags.Count != 0)
                {
                    foreach (var tag in tags)
                    {
                        if (tag.Type == "new")
                        {
                            _tag.TagId = 0;
                            _tag.UserId = folder.UserId;
                            _tag.TagContent = tag.TagContent;
                            _tag.Color = tag.Color;
                            _tag.TagId = await _repositoriesManager.Tags.CreateAsync(_tag);
                            newTagsId.Add(_tag.TagId);

                        }
                        else if (tag.Type == "existing")
                        {
                            bool create = true;
                            foreach (int[] ids in FolderTagIds)
                            {
                                if (ids[2] == Convert.ToInt32(tag.TagId))
                                {
                                    create = false;
                                    break;
                                }
                            }

                            if (create)
                            {
                                addTags.Add(Convert.ToInt32(tag.TagId));
                            }
                            else 
                            {
                                tagIdsFromFolder.Remove(Convert.ToInt32(tag.TagId));
                            }
                        }
                    }
                }


                foreach (int id in tagIdsFromFolder)
                {
                    int count = (await _repositoriesManager.FolderTags.GetAllFolderIdByTagAsync(id)).Count;
                    if (count == 1)
                    {
                        deleteTags.Add(id); // extract the ids of the tags that only exist in this folder to delete them later.
                    }

                    foreach (int[] ids in FolderTagIds)
                    {
                        if (ids[2] == id) 
                        {
                            await _repositoriesManager.FolderTags.DeleteAsync(ids[0]);
                        }
                    }

                }

                foreach (int id in newTagsId)
                {
                    _folderTag.FolderId = folderDomainModel.FolderId;
                    _folderTag.TagId = id;
                    int result = await _repositoriesManager.FolderTags.CreateAsync(_folderTag);
                }

                foreach (int id in addTags)
                {
                    _folderTag.FolderId = folderDomainModel.FolderId;
                    _folderTag.TagId = id;
                    int result = await _repositoriesManager.FolderTags.CreateAsync(_folderTag);
                }

                foreach (int id in deleteTags)
                {
                    await _repositoriesManager.Tags.DeleteAsync(id); // delete tags 
                }

                _folder.FolderName = (folderDomainModel.FolderName.IsNullOrEmpty()) ? _folder.FolderName : folderDomainModel.FolderName;
                _folder.LastModifiedDate = (folderDomainModel.LastModifiedAt > _folder.LastModifiedDate) ? folderDomainModel.LastModifiedAt : _folder.LastModifiedDate;
                await _repositoriesManager.Folders.UpdateAsync(_folder);
                await _repositoriesManager.CommitAsync();

            }
            catch (Exception ex)
            {
                if (newTagsId.Count != 0)
                {
                    foreach (int id in newTagsId)
                    {
                        await _repositoriesManager.Tags.DeleteAsync(id);
                    }
                }

                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteFolder(int folderId)
        {
            try
            {
                List<int> TagsInFolder = await _repositoriesManager.FolderTags.GetAllTagIdByFolderAsync(folderId);
                List<int> numberFoldersBytag = new List<int>();

                foreach (int id in TagsInFolder) 
                { 
                    int count = (await _repositoriesManager.FolderTags.GetAllFolderIdByTagAsync(id)).Count;
                    if (count == 1) 
                    {
                        numberFoldersBytag.Add(id); // extract the ids of the tags that only exist in this folder to delete them later.
                    }
                }

                List<int[]> FolderTagIds = await _repositoriesManager.FolderTags.GetAllByFolderAsync(folderId);

                foreach (int[] ids in FolderTagIds) 
                {
                    await _repositoriesManager.FolderTags.DeleteAsync(ids[0]); // delete the relations of the tags with the folder
                }

                foreach (int id in numberFoldersBytag)
                {
                    await _repositoriesManager.Tags.DeleteAsync(id); // delete tags 
                }

                List<int> pageInFolder = await _repositoriesManager.Pages.GetAllByFolderAsync(folderId);

                foreach (int id in pageInFolder) 
                {
                    await _repositoriesManager.Pages.DeleteAsync(id);
                }

                await _repositoriesManager.Folders.DeleteAsync(folderId);

                await _repositoriesManager.CommitAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
