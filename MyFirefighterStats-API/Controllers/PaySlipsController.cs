// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="PaySlipsController.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirefighterStats.API.Data;
using MyFirefighterStats.API.DTO.PaySlip;
using MyFirefighterStats.API.Entities;

[Route("api/[controller]")]
[ApiController]
public class PaySlipsController : ControllerBase
{
    private readonly ApplicationDbContext context;

    private readonly IMapper mapper;

    public PaySlipsController(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PaySlipDTO>> GetPaySlips()
    {
        List<PaySlip> paySlips = await this.context.PaySlips.Include(static p => p.PaySlipLines).AsNoTracking().ToListAsync();

        return this.mapper.Map<List<PaySlipDTO>>(paySlips);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PaySlipDTO>> GetPaySlip(int id)
    {
        PaySlip? paySlip = await this.context.PaySlips.Include(static p => p.PaySlipLines).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        return paySlip == null
                   ? this.NotFound()
                   : this.mapper.Map<PaySlipDTO>(paySlip);
    }

    [HttpPost]
    public async Task<ActionResult<PaySlipDTO>> PostPaySlip([FromBody] PaySlipCreationDTO paySlipCreation)
    {
        var paySlip = this.mapper.Map<PaySlip>(paySlipCreation);

        _ = this.context.PaySlips.Add(paySlip);
        _ = await this.context.SaveChangesAsync();

        return this.CreatedAtAction(nameof(this.GetPaySlip), new
        {
            id = paySlip.Id,
        }, this.mapper.Map<PaySlipDTO>(paySlip));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> PutPaySlip(int id, [FromBody] PaySlipUpdateDTO paySlipUpdate)
    {
        var paySlip = this.mapper.Map<PaySlip>(paySlipUpdate);
        paySlip.Id = id;

        this.context.Entry(paySlip).State = EntityState.Modified;

        _ = await this.context.SaveChangesAsync();

        var paySlipDTO = this.mapper.Map<PaySlipDTO>(paySlip);

        return this.CreatedAtAction(nameof(this.GetPaySlip), new
        {
            id,
        }, paySlipDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletePaySlip(int id)
    {
        PaySlip? paySlip = await this.context.PaySlips.Include(static p => p.PaySlipLines).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        if (paySlip == null)
        {
            return this.NotFound();
        }

        paySlip.PaySlipLines.Clear();

        _ = this.context.PaySlips.Remove(paySlip);

        _ = await this.context.SaveChangesAsync();

        return this.NoContent();
    }
}