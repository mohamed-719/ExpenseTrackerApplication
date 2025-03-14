﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Entities.Models;

namespace AppNtier.Entities.Models;

public class TransactionOf
{
    [Key]
    public int TransactionId { get; set; }

    [Required]
    [ForeignKey("Category")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }  

    [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
    public decimal Amount { get; set; }  

    [Column(TypeName = "nvarchar(75)")]
    public string? Note { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    [NotMapped]
    public string CategoryTitleWithIcon => Category == null ? "" : $"{Category.Icon} {Category.Title}";

    [NotMapped]
    public string FormattedAmount => $"{(Category == null || Category.Type == CategoryType.Expense ? "- " : "+ ")}{Amount:C0}";
}

