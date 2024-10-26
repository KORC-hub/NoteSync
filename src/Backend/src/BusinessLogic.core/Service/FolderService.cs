using AutoMapper;
using Azure;
using BusinessLogic.core.UseCases;
using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.Abstractions.UoW;
using DataAccess.SqlServer.Models;
using DomainModel;
using DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<int> CreateFolder(FolderDto folder, List<TagDto>? tags)
        {
            try 
            { 
                FolderDomainModel folderDomainModel = _mapper.Map<FolderDomainModel>(folder);

                _folder.FolderName = folderDomainModel.FolderName;
                _folder.UserId = folderDomainModel.UserId;

                folderDomainModel.FolderId =  await _repositoriesManager.Folders.CreateAsync(_folder);

                List<int> newTagsId = new List<int>();
                List<int> existingTagsId = new List<int>();

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
                throw new Exception(ex.Message);
            }

        }

        public Task DeleteFolder(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFolder(FolderDto folder)
        {
            throw new NotImplementedException();
        }
    }
}
