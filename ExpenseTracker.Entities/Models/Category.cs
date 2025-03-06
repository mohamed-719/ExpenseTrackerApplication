using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Entities.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    [Column(TypeName = "nvarchar(5)")]
    public string? Icon { get; set; } = ""; 

    [Column(TypeName = "nvarchar(10)")]
    public CategoryType Type { get; set; } = CategoryType.Expense;

    [NotMapped]
    public string TitleWithIcon => $"{Icon} {Title}".Trim();
}

public enum CategoryType
{
    Income,
    Expense
}