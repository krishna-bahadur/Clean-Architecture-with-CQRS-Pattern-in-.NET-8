using Application.Resources.Items.Commands.CreateItem;
using Application.Resources.Items.Queries.GetAllItems;
using Application.Resources.Items.Queries.GetItemById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Presentation.EndPoints.Items;

public static class ItemEndPoints
{
    public static void MapItemEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("Item/get-by-id", async (Guid Id, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            try
            {
                var query = new GetItemByIdQuery(Id);

                var response = await _mediator.Send(query, cancellationToken);

                return response is not null ? Results.Ok(response) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
            
        });
        
        app.MapGet("Item/get-all", async (IMediator _mediator, CancellationToken cancellationToken) =>
        {
            try
            {
                var query = new GetAllItemsQuery();

                var response = await _mediator.Send(query, cancellationToken);

                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
            
        });
        
        app.MapPost("Item/create", async ([FromBody] Item item, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            try
            {
                var command = new CreateItemCommand()
                {
                    Id = Guid.NewGuid(),
                    Name = item.Name,
                    Description= item.Description,
                    Price = item.Price,
                };

                var response = await _mediator.Send(command, cancellationToken);

                return response != Guid.Empty ? Results.Created() : Results.BadRequest();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
            
        });
    }
}
