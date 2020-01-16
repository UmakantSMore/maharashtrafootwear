using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_porderproducts_b
    {

        #region Constructor
        public Cls_porderproducts_b()
        { }
        #endregion

        #region Public Methods
        public DataTable SelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_porderproducts_db objCls_porderproducts_db = new Cls_porderproducts_db();

                dt = objCls_porderproducts_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public porderproducts SelectById(Int64 opid)
        {
            porderproducts objporderproducts = new porderproducts();
            try
            {
                Cls_porderproducts_db objCls_porderproducts_db = new Cls_porderproducts_db();

                objporderproducts = objCls_porderproducts_db.SelectById(opid);
                return objporderproducts;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objporderproducts;
            }
        }
        public Int64 Insert(porderproducts objporderproducts)
        {
            Int64 result = 0;
            try
            {
                Cls_porderproducts_db objCls_porderproducts_db = new Cls_porderproducts_db();

                result = Convert.ToInt64(objCls_porderproducts_db.Insert(objporderproducts));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(porderproducts objporderproducts)
        {
            Int64 result = 0;
            try
            {
                Cls_porderproducts_db objCls_porderproducts_db = new Cls_porderproducts_db();

                result = Convert.ToInt64(objCls_porderproducts_db.Update(objporderproducts));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public bool Delete(Int64 opid)
        {
            try
            {
                Cls_porderproducts_db objCls_porderproducts_db = new Cls_porderproducts_db();

                if (objCls_porderproducts_db.Delete(opid))
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
    public class porderproducts
    {
        public porderproducts()
        { }

        #region Private Variables
        private Int64 _opid;
        private Int64 _oid;
        private Int64 _uid;
        private Int64 _pid;
        private string _brandid;
        private string _sizeid;
        private string _colorid;
        private Decimal _cart;
        private string _pack;
        private Decimal _qty;

        private Decimal _mrp;
        private Decimal _unitRate;
        private Decimal _subTotal;
        private Decimal _discount;
        private Decimal _scheme;
        private Decimal _taxableamt;
        private Decimal _CGSTper;
        private Decimal _SGSTper;
        private Decimal _IGSTper;
        private Decimal _GSTamt;
        private Decimal _TotalAmount;
        private Boolean _isdelete;
        #endregion


        #region Public Properties
        public Int64 opid
        {
            get { return _opid; }
            set { _opid = value; }
        }
        public Int64 oid
        {
            get { return _oid; }
            set { _oid = value; }
        }
        public Int64 uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public Int64 pid
        {
            get { return _pid; }
            set { _pid = value; }
        }


        public string brandid
        {
            get { return _brandid; }
            set { _brandid = value; }
        }
        public string sizeid
        {
            get { return _sizeid; }
            set { _sizeid = value; }
        }
        public string colorid
        {
            get { return _colorid; }
            set { _colorid = value; }
        }
        public Decimal cart
        {
            get { return _cart; }
            set { _cart = value; }
        }
        public string pack
        {
            get { return _pack; }
            set { _pack = value; }
        }
        public decimal qty
        {
            get { return _qty; }
            set { _qty = value; }
        }


        public decimal mrp
        {
            get { return _mrp; }
            set { _mrp = value; }
        }
        public decimal unitRate
        {
            get { return _unitRate; }
            set { _unitRate = value; }
        }
        public decimal subTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }
        public decimal discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
        public decimal scheme
        {
            get { return _scheme; }
            set { _scheme = value; }
        }
        public decimal taxableamt
        {
            get { return _taxableamt; }
            set { _taxableamt = value; }
        }
        public decimal CGSTper
        {
            get { return _CGSTper; }
            set { _CGSTper = value; }
        }


        public decimal SGSTper
        {
            get { return _SGSTper; }
            set { _SGSTper = value; }
        }

        public decimal IGSTper
        {
            get { return _IGSTper; }
            set { _IGSTper = value; }
        }

        public decimal GSTamt
        {
            get { return _GSTamt; }
            set { _GSTamt = value; }
        }

        public decimal TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }



        public Boolean isdelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }
        #endregion
    }

}
