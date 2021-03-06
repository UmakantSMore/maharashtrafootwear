﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_porders_b
    {

        #region Constructor
        public Cls_porders_b()
        { }
        #endregion

        #region Public Methods
        public DataSet SelectAll()
        {
            DataSet dt = new DataSet();
            try
            {
                Cls_porders_db objCls_porders_db = new Cls_porders_db();
                dt = objCls_porders_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public porders SelectById(Int64 oid)
        {
            porders objporders = new porders();
            try
            {
                Cls_porders_db objCls_porders_db = new Cls_porders_db();

                objporders = objCls_porders_db.SelectById(oid);
                return objporders;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objporders;
            }
        }
        public Int64 Insert(porders objporders)
        {
            Int64 result = 0;
            try
            {
                Cls_porders_db objCls_porders_db = new Cls_porders_db();

                result = Convert.ToInt64(objCls_porders_db.Insert(objporders));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(porders objporders)
        {
            Int64 result = 0;
            try
            {
                Cls_porders_db objCls_porders_db = new Cls_porders_db();

                result = Convert.ToInt64(objCls_porders_db.Update(objporders));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public bool Delete(Int64 oid)
        {
            try
            {
                Cls_porders_db objCls_porders_db = new Cls_porders_db();

                if (objCls_porders_db.Delete(oid))
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

        public DataTable Selectorderdetailsbydealerid(Int64 suppleirId)
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_porders_db objCls_porders_db = new Cls_porders_db();
                dt = objCls_porders_db.Selectporderdetailsbysupplierid(suppleirId);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }


        #endregion


    }
    public class porders
    {
        public porders()
        { }

        #region Private Variables

        #endregion
        private Int64 _oid;
        private Int64 _uid;
        private string _paymentType;
        private string _invoicetype;
        private string _orderno;
        private string _paymentMode;
        private DateTime _orderdate;
        private decimal _subamount;
        private decimal _totalGSTAmount;
        private decimal _per_tradeDisandScheme;
        private decimal _amt_tradeDisandScheme;
        private decimal _per_taxableDiscount;
        private decimal _amt_taxableDiscount;
        private decimal _TaxableAmount;
        private decimal _TotalAmount;
        private decimal _CGSTamt;
        private decimal _SGSTamt;
        private decimal _IGSTamt;
        private decimal _otheramt;
        private decimal _freightDiscount;
        private DateTime _duedate;
        private decimal _grandTotal;
        private string _Referenceby;
        private string _DeliveredThrough;
        private string _DeliveredDetails;
        private Int64 _orderstatus;
        private string _ordertype;
        private decimal _pendingAmt;
        private bool _isconfirmed;

        #region Public Properties
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
        public string paymentType
        {
            get { return _paymentType; }
            set { _paymentType = value; }
        }

        public string invoicetype
        {
            get { return _invoicetype; }
            set { _invoicetype = value; }
        }
        public string orderno
        {
            get { return _orderno; }
            set { _orderno = value; }
        }
        public string paymentMode
        {
            get { return _paymentMode; }
            set { _paymentMode = value; }
        }
        public DateTime orderdate
        {
            get { return _orderdate; }
            set { _orderdate = value; }
        }
        public decimal subamount
        {
            get { return _subamount; }
            set { _subamount = value; }
        }
        public decimal totalGSTAmount
        {
            get { return _totalGSTAmount; }
            set { _totalGSTAmount = value; }
        }
        public decimal per_tradeDisandScheme
        {
            get { return _per_tradeDisandScheme; }
            set { _per_tradeDisandScheme = value; }
        }
        public decimal amt_tradeDisandScheme
        {
            get { return _amt_tradeDisandScheme; }
            set { _amt_tradeDisandScheme = value; }
        }
        public decimal per_taxableDiscount
        {
            get { return _per_taxableDiscount; }
            set { _per_taxableDiscount = value; }
        }
        public decimal amt_taxableDiscount
        {
            get { return _amt_taxableDiscount; }
            set { _amt_taxableDiscount = value; }
        }
        public decimal TaxableAmount
        {
            get { return _TaxableAmount; }
            set { _TaxableAmount = value; }
        }
        public decimal TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }
        public decimal CGSTamt
        {
            get { return _CGSTamt; }
            set { _CGSTamt = value; }
        }
        public decimal SGSTamt
        {
            get { return _SGSTamt; }
            set { _SGSTamt = value; }
        }
        public decimal IGSTamt
        {
            get { return _IGSTamt; }
            set { _IGSTamt = value; }
        }
        public decimal otheramt
        {
            get { return _otheramt; }
            set { _otheramt = value; }
        }
        public decimal freightDiscount
        {
            get { return _freightDiscount; }
            set { _freightDiscount = value; }
        }
        public DateTime duedate
        {
            get { return _duedate; }
            set { _duedate = value; }
        }
        public decimal grandTotal
        {
            get { return _grandTotal; }
            set { _grandTotal = value; }
        }
        public string Referenceby
        {
            get { return _Referenceby; }
            set { _Referenceby = value; }
        }
        public string DeliveredThrough
        {
            get { return _DeliveredThrough; }
            set { _DeliveredThrough = value; }
        }
        public string DeliveredDetails
        {
            get { return _DeliveredDetails; }
            set { _DeliveredDetails = value; }
        }
        public Int64 orderstatus
        {
            get { return _orderstatus; }
            set { _orderstatus = value; }
        }
        public string ordertype
        {
            get { return _ordertype; }
            set { _ordertype = value; }
        }
        public decimal pendingAmt
        {
            get { return _pendingAmt; }
            set { _pendingAmt = value; }
        }

        public bool isconfirmed
        {
            get { return _isconfirmed; }
            set { _isconfirmed = value; }
        }




        #endregion
    }

}
