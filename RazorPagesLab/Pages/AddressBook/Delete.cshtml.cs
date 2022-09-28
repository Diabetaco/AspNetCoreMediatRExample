using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesLab.Pages.AddressBook;

public class DeleteModel : PageModel
{
    private readonly IMediator _mediator;
    private readonly IRepo<AddressBookEntry> _repo;


    public DeleteModel(IRepo<AddressBookEntry> repo, IMediator mediator)
    {
        _repo = repo;
        _mediator = mediator;
    }

    [BindProperty]
    public DeleteAddressRequest DeleteAddressRequest { get; set; }

    public void OnGet(Guid id)
    {
        IEnumerable<AddressBookEntry> AddressBookEntries = _repo.Find(new AllEntriesSpecification());

        foreach (AddressBookEntry entry in AddressBookEntries)
        {
            if (entry.Id == id)
            {

                DeleteAddressRequest = new DeleteAddressRequest();

                DeleteAddressRequest.Line1 = entry.Line1;
                DeleteAddressRequest.Line2 = entry.Line2;
                DeleteAddressRequest.City = entry.City;
                DeleteAddressRequest.State = entry.State;
                DeleteAddressRequest.PostalCode = entry.PostalCode;
                DeleteAddressRequest.Id = entry.Id;
            }
        }
    }



    public async Task<ActionResult> OnPostDelete()
    {
        _ = await _mediator.Send(DeleteAddressRequest);
        return RedirectToPage("Index");
    }

    public ActionResult OnPostCancel()
    {
        return RedirectToPage("Index");
    }
}