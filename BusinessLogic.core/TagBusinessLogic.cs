using DataAccess.sql;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.core
{
    public class TagBusinessLogic
    {
        #region Private Variables
        private QueryExecuter _query = null;
        #endregion

        #region Execute Method
        private void Execute(ref Entities.Tag Tag)
        {
            _query.Execute(ref _query);
            if (_query.ErrorMessage == null)
            {
                if (_query.Scalar)
                {
                    Tag.ScalarValue = _query.ScalarValue;
                }
                else
                {
                    Tag.DataSetResultado = _query.DataSetResult.Tables[0];
                    if (Tag.DataSetResultado.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tag.DataSetResultado.Rows)
                        {
                            Tag.TagId = Convert.ToInt32(item[0]);
                            Tag.UserId = Convert.ToInt32(item[1]);
                            Tag.TagContent = Convert.ToString(item[2]);
                            Tag.Color = Convert.ToString(item[3]);
                        }
                    }
                }
            }
            else
            {
                Tag.ErrorMessage = _query.ErrorMessage;
            }
        }
        #endregion

        #region CRUD Methods
        // Crear una etiqueta y relacionarla con un archivo
        public void CreateTag(ref Tag Tag, int fileId)
        {
            _query = new QueryExecuter
            {
                TableName = "[Tag]",
                StoredProcedureName = "[SP_Tag_Create]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@TagContent", "16", Tag.TagContent);
            _query.DataTableParameters.Rows.Add(@"@UserId", "4", Tag.UserId);
            _query.DataTableParameters.Rows.Add(@"@Color", "15", Tag.Color);

            Execute(ref Tag);
            Tag.TagId = Convert.ToInt32(_query.ScalarValue);  // Asigna el TagId generado

            // Relacionar el tag con el archivo
            //CreateFileTagRelation(fileId, Tag.TagId);
        }

        // Leer las etiquetas de un archivo
        public void ReadTags(ref Tag Tag)
        {
            _query = new QueryExecuter
            {
                TableName = "[FileTag]",
                StoredProcedureName = "[SP_Tag_Read]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@UserId", SqlDbType.Int, Tag.UserId);

            Execute(ref Tag);
        }

        // Eliminar etiqueta
        public void DeleteTag(ref Tag Tag)
        {
            _query = new QueryExecuter
            {
                TableName = "[Tag]",
                StoredProcedureName = "[SP_Tag_Delete]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@TagId", "4", Tag.TagId);

            _query.Execute(ref _query);
        }
        #endregion
    }
}
