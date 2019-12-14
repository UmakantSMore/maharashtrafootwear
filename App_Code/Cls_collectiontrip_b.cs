using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_collectiontrip_b
    {
        public Cls_collectiontrip_b()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Public Methods

        public DataTable SelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_collectiontrip_db objCls_collectiontrip_db = new Cls_collectiontrip_db();
                dt = objCls_collectiontrip_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }


        public collectiontrip SelectById(Int64 id)
        {
            collectiontrip objcollectiontrip = new collectiontrip();
            try
            {
                Cls_collectiontrip_db objCls_collectiontrip_db = new Cls_collectiontrip_db();

                objcollectiontrip = objCls_collectiontrip_db.SelectById(id);
                return objcollectiontrip;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objcollectiontrip;
            }
        }

        public Int64 Insert(collectiontrip objcollectiontrip)
        {
            Int64 result = 0;
            try
            {
                Cls_collectiontrip_db objCls_collectiontrip_db = new Cls_collectiontrip_db();

                result = Convert.ToInt64(objCls_collectiontrip_db.Insert(objcollectiontrip));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public Int64 Update(collectiontrip objcollectiontrip)
        {
            Int64 result = 0;
            try
            {
                Cls_collectiontrip_db objCls_collectiontrip_db = new Cls_collectiontrip_db();

                result = Convert.ToInt64(objCls_collectiontrip_db.Update(objcollectiontrip));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public bool Delete(Int32 bankid)
        {
            try
            {
                Cls_collectiontrip_db objCls_collectiontrip_db = new Cls_collectiontrip_db();

                if (objCls_collectiontrip_db.Delete(bankid))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion


    }
    public class collectiontrip
    {
        public collectiontrip()
        { }

        #region Private Variables

        // id, weekday, cityname, empid, empname, isdeleted


        private Int64 _id;
        private Int64 _empid;
        private String _weekday;
        private String _cityname;
        private String _empname;
        private Boolean _isdelete;
        #endregion


        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Int64 empid
        {
            get { return _empid; }
            set { _empid = value; }
        }
        public String weekday
        {
            get { return _weekday; }
            set { _weekday = value; }
        }
        public String cityname
        {
            get { return _cityname; }
            set { _cityname = value; }
        }
        public String empname
        {
            get { return _empname; }
            set { _empname = value; }
        }
        public Boolean isdelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }



        #endregion
    }

}
