using System.ComponentModel.DataAnnotations;
using TaskPlanner2.Models.DataBase;

namespace TaskPlanner2.Models.ViewModel
{
    public class ToDoTaskViewModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }

    public static class ToDoTaskMapping
    {
        public static ToDoTask ToTask(this ToDoTaskViewModel viewModel)
        {
            return new ToDoTask
            {
                Title = viewModel.Title,
                Description = viewModel.Description
            };
        }
    }
}
