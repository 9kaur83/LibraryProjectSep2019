﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProjectSep2019
{
    class Customer
    {
        private static int lastCustomerId = 0;

        #region Properties
        /// <summary>
        /// Name of the customer.
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Phone number of the customer.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email address of the customer.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// mailing address of the customer.
        /// </summary>
        public string Address { get; set; }
        /// <summary
        /// Autogenerated customer user ID.
        /// </summary>
        public int UserIDOfCustomer { get; set; }

        #endregion

        #region Constructor

        public Customer()
        {
            UserIDOfCustomer = ++lastCustomerId;
        }

        #endregion
    }
}
