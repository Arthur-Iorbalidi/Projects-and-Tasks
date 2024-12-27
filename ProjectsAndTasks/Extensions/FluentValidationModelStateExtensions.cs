using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ProjectsAndTasks.Extensions
{
	public static class FluentValidationModelStateExtensions
	{
		public static void AddToModelState(this FluentValidation.Results.ValidationResult result, ModelStateDictionary modelState)
		{
			foreach (var error in result.Errors)
			{
				modelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}
	}
}
