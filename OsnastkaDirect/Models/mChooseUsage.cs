using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//
using Fox;
using OsnastkaDirect.Data;
//
namespace OsnastkaDirect.Models
{
    /// <summary>
    /// Класс mChooseUsage (Model)
    /// </summary>
    class mChooseUsage : MBase
    {
        #region Переменные

            /// <summary>
            /// Переменная для работы с базой данных
            /// </summary>
            public FOXEntities db;
        //
        // Переменная для свойства
        //
        //тип name;

        #endregion

        #region Свойства

        // 
        // Свойство
        //
        //public тип pName
        //{
        //    get { return name; }
        //    set
        //    {
        //        name = value;
        //        OnPropertyChanged("pName");
        //    }
        //}    
        List<TypeProduct> ListTypeProduct;
        public List<TypeProduct> pListTypeProduct
        {
            get { return ListTypeProduct; }
            set
            {
                if (ListTypeProduct != value)
                {
                    ListTypeProduct = value;
                    OnPropertyChanged("pListTypeProduct");
                }
            }
        }

        List<Product> ListProduct;
        public List<Product> pListProduct
        {
            get { return ListProduct; }
            set
            {
                if (ListProduct != value)
                {
                    ListProduct = value;
                    OnPropertyChanged("pListProduct");
                }
            }
        }

        TypeProduct SelTypeProduct;
        public TypeProduct pSelTypeProduct
        {
            get { return SelTypeProduct; }
            set
            {
                if (SelTypeProduct != value)
                {
                    SelTypeProduct = value;
                    OnPropertyChanged("pSelTypeProduct");
                }
            }
        }
        Product SelProduct;
        public Product pSelProduct
        {
            get { return SelProduct; }
            set
            {
                if (SelProduct != value)
                {
                    SelProduct = value;
                    OnPropertyChanged("pSelProduct");
                }
            }
        }

        bool IsOpenUsageGeneral = false;
        public bool pIsOpenUsageGeneral
        {
            get { return IsOpenUsageGeneral; }
            set
            {
                if (IsOpenUsageGeneral != value)
                {
                    IsOpenUsageGeneral = value;
                    OnPropertyChanged("pIsOpenUsageGeneral");
                }
            }
        }

        bool IsOpenUsageProduct = false;
        public bool pIsOpenUsageProduct
        {
            get { return IsOpenUsageProduct; }
            set
            {
                if (IsOpenUsageProduct != value)
                {
                    IsOpenUsageProduct = value;
                    OnPropertyChanged("pIsOpenUsageProduct");
                }
            }
        }
        #endregion

        #region Методы

        /// <summary>
        /// Конструктор
        /// </summary>
        public mChooseUsage()
            {
                db = VMLocator.VMs["Main"][VMLocator.mainKey].model.db;
            //
            // Инициализация свойств
            // pName = значение;
            //if (pIsOpenUsageProduct)
                LoadListProduct();
            //if (pIsOpenUsageGeneral)
                LoadListTypeProduct();
        }
        public void LoadListTypeProduct()
        {
            pListTypeProduct = (from i in db.iztyp
                                select new TypeProduct
                                {
                                    product = i.izdelie,
                                    type = i.iz,
                                }).ToList();
        }
        public void LoadListProduct()
        {
            pListProduct = (from i in db.prodact
                            select new Product
                            {
                                product = i.name,
                                draft = i.draft,
                            }).ToList();
        }
        #endregion
    }
}

