﻿////////////////////////////////////////////////////////////////////////////////////////////////////////////////// //
// Project: SystemTextJson
// File Name: Book.cs
// Description: 
// Course: CSCI-2910-940
// Author: Sydni Ward
// Created: 11/14/2020
// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;

namespace NewtonSoftProject
{
    class Book
    {
        public string totalItems { get; set; }
        public string kind { get; set; }
        public IList<Items> items { get; set; }
    }
}