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

    public void OnGet(Guid id)
    {
    }

    [BindProperty]
    public DeleteAddressRequest DeleteAddressRequest { get; set; }

    public async Task<ActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            _ = await _mediator.Send(DeleteAddressRequest);
            return RedirectToPage("Index");
        }

        return Page();
    }
}