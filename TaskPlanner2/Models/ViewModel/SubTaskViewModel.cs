using System.ComponentModel.DataAnnotations;
using TaskPlanner2.Models.DataBase;

namespace TaskPlanner2.Models.ViewModel
{
    public class SubTaskViewModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int TaskId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }

    public static class SubTaskMapping
    {
        public static SubTask ToSubTask(this SubTaskViewModel viewModel)
        {
            return new SubTask
            {
                Description = viewModel.Description
            };
        }
    }
}
