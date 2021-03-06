﻿using EmployeeManagement.API.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.CookiePolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public bool ShowFooter { get; set; } = true;
        protected Blazor.Components.ConfirmBase DeletConfirmation { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
        protected async Task EmployeeDeleted()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
        public int SelectedEmployeesCount { get; set; } = 0;

        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if(isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
        }

        protected void HandleValidSubmit()
        {

        }

        protected void Delete_Click()
        {
            DeletConfirmation.Show();
        }

        //protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        //{
        //    if(deleteConfirmed)
        //    {
        //        await EmployeeService.DeleteEmployee(Employee.EmployeeId);
        //    }
        //}
    }
}
