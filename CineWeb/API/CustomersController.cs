﻿using CineWeb.DomainEntities;
using CineWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CineWeb.API
{
    public class CustomersController : ApiController
    {
            private ApplicationDbContext _context;

            public CustomersController()
            {
                _context = new ApplicationDbContext();
            }

            //GET /api/customers
            public IEnumerable<Customer> GetCustomers()
            {
                return _context.Customers.ToList();
            }

            //GET /api/customers/id
            public Customer GetCustomer(int id)
            {
                var customer = _context.Customers.SingleOrDefault(p => p.CustomerId == id);
                if (customer == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                return customer;
            }

            //POST /api/customers
            [HttpPost]
            public Customer CreateCustomer(Customer customer)
            {
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                _context.Customers.Add(customer);
                _context.SaveChanges();

                return customer;
            }

            //PUT /api/customers/id
            [HttpPut]
            public void UpdateCustomer(int id, Customer customer)
            {
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                var customerInDb = _context.Customers.Single(p => p.CustomerId == id);

                if (customerInDb == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                customerInDb.CustomerName = customer.CustomerName;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customer.MembershipTypeId = customer.MembershipTypeId;

                _context.SaveChanges();
            }

            //DELETE /api/customers/id
            [HttpDelete]
            public void DeleteCustomer(int id)
            {
                var customerInDb = _context.Customers.Single(p => p.CustomerId == id);

                if (customerInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
            }
        }

    }

