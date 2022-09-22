using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesLab.Pages.AddressBook;

public class EditModel : PageModel
{
	private readonly IMediator _mediator;
	private readonly IRepo<AddressBookEntry> _repo;

	public EditModel(IRepo<AddressBookEntry> repo, IMediator mediator)
	{
		_repo = repo;
		_mediator = mediator;
	}

	[BindProperty]
	public UpdateAddressRequest UpdateAddressRequest { get; set; }

	public void OnGet(Guid id)
	{
        IEnumerable<AddressBookEntry> AddressBookEntries = _repo.Find(new AllEntriesSpecification());

		foreach (AddressBookEntry entry in AddressBookEntries)
		{
			if (entry.Id == id)
			{
				UpdateAddressRequest = new UpdateAddressRequest();

				UpdateAddressRequest.Line1 = entry.Line1;
                UpdateAddressRequest.Line2 = entry.Line2;
                UpdateAddressRequest.City = entry.City;
                UpdateAddressRequest.State = entry.State;
                UpdateAddressRequest.PostalCode = entry.PostalCode;
				UpdateAddressRequest.Id = entry.Id;
				_repo.Update(entry);
            }
		}

		
        // Todo: Use repo to get address book entry, set UpdateAddressRequest fields.
    }

    public async Task<ActionResult> OnPost()
    {
        if (ModelState.IsValid)
		{
            _ = await _mediator.Send(UpdateAddressRequest);
			return RedirectToPage("Index");
		}
		// Todo: Use mediator to send a "command" to update the address book entry, redirect to entry list.
        return Page();
	}
}