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
    public class PageBusinessLogic
    {
        #region Private Variables
        private QueryExecuter _query;
        #endregion

        #region Execute Method
        private void Execute(ref Entities.Page Page)
        {
            _query.Execute(ref _query);
            if (_query.ErrorMessage == null)
            {
                if (_query.Scalar)
                {
                    Page.ScalarValue = _query.ScalarValue;
                }
                else
                {
                    Page.DataSetResultado = _query.DataSetResult.Tables[0];
                    if (Page.DataSetResultado.Rows.Count > 0)
                    {
                        foreach (DataRow item in Page.DataSetResultado.Rows)
                        {
                            Page.PageId = Convert.ToInt32(item[0]);
                            Page.Content = Convert.ToString(item[1]);
                            Page.FileId = Convert.ToInt32(item[2]);
                            Page.Title = Convert.ToString(item[3]);
                        }
                    }
                }
            }
            else
            {
                Page.ErrorMessage = _query.ErrorMessage;
            }
        }
        #endregion

        #region CRUD Methods
        // Crear una página en un archivo
        public void CreatePage(ref Page page)
        {
            _query = new QueryExecuter
            {
                TableName = "[Page]",
                StoredProcedureName = "[SP_Page_Create]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@FileId", "4", page.FileId);
            _query.DataTableParameters.Rows.Add(@"@Content", "16", page.Content);

            Execute(ref page);
            page.PageId = Convert.ToInt32(_query.ScalarValue);  // Asigna el PageId generado
        }

        // Leer una página
        public void ReadPage(ref Page page)
        {
            _query = new QueryExecuter
            {
                TableName = "[Page]",
                StoredProcedureName = "[SP_Page_Read]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@PageId", "4", page.PageId);

            Execute(ref page);
        }

        // Actualizar el contenido de una página
        public void UpdatePage(ref Page page)
        {
            _query = new QueryExecuter
            {
                TableName = "[Page]",
                StoredProcedureName = "[SP_Page_Update]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@PageId", "4", page.PageId);
            _query.DataTableParameters.Rows.Add(@"@Content", "16", page.Content);

            Execute(ref page);
        }

        // Eliminar una página
        public void DeletePage(ref Page page)
        {
            _query = new QueryExecuter
            {
                TableName = "[Page]",
                StoredProcedureName = "[SP_Page_Delete]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@PageId", "4", page.PageId);

            Execute(ref page);
        }
        #endregion
    }
}
