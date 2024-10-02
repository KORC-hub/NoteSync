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
    public class FileBusinessLogic
    {
        #region Private Variables
        private QueryExecuter _query = null;
        #endregion

        #region Execute Method
        private void Execute(ref Entities.File File)
        {
            _query.Execute(ref _query);
            if (_query.ErrorMessage == null)
            {
                if (_query.Scalar)
                {
                    File.ScalarValue = _query.ScalarValue;
                }
                else
                {
                    File.DataSetResultado = _query.DataSetResult.Tables[0];
                    if (File.DataSetResultado.Rows.Count > 0)
                    {
                        foreach (DataRow item in File.DataSetResultado.Rows)
                        {
                            File.FileId = Convert.ToInt32(item[0]);
                            File.CreatedAt = Convert.ToDateTime(item[1]);
                            File.LastModifiedAt = Convert.ToDateTime(item[2]);
                            File.UserId = Convert.ToInt32(item[3]);
                        }
                    }
                }
            }
            else
            {
                File.ErrorMessage = _query.ErrorMessage;
            }
        }
        #endregion

        #region CRUD Methods
        public int CreateFile(ref Entities.File File)
        { 
            _query = new QueryExecuter
            {
                TableName = "[File]",
                StoredProcedureName = "[SP_File_Create]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@UserId", "4", File.UserId);
            Execute(ref File);

            return Convert.ToInt32(_query.ScalarValue);  // Devuelve el ID del archivo recién creado
        }

        public void UpdateFile(ref Entities.File File)
        {
            _query = new QueryExecuter
            {
                TableName = "[File]",
                StoredProcedureName = "[SP_File_Update]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@FileId", "4", File.FileId);
            _query.Execute(ref _query);
            Execute(ref File);
        }

        public void ReadFile(ref Entities.File File)
        {
            _query = new QueryExecuter
            {
                TableName = "[File]",
                StoredProcedureName = "[SP_File_Read]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@FileId", "4", File.FileId);
            Execute(ref File);
        }

        // Eliminar archivo
        public void DeleteFile(ref Entities.File File)
        {
            _query = new QueryExecuter
            {
                TableName = "[File]",
                StoredProcedureName = "[SP_File_Delete]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@FileId", "4", File.FileId);
            Execute(ref File);
        }
        #endregion
    }
}
