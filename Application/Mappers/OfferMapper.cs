using Unite.WebApi.Application.ViewModels.Offers;
using Unite.WebApi.Domain.Entities;
using Unite.WebApi.Domain.Enums;

namespace Unite.WebApi.Application.Mappers
{
    public static class OfferMapper
    {
        public static Offer MapInputToOfferModel(OfferInput offerInput)
        {
            var offer = new Offer();

            offer.Id = Guid.NewGuid();
            offer.Queue = offerInput.Queue;
            offer.TargetTier = offerInput.TargetTier;
            offer.IsTierRestricted = offerInput.IsTierRestricted;
            offer.Status = OfferStatus.CREATED;
            offer.CreatedAt = DateTime.Now;
            offer.Notes = offerInput.Notes;
            offer.TargetPosition1 = offerInput.TargetPosition1;
            offer.TargetPosition2 = offerInput.TargetPosition2;
            offer.TargetPosition3 = offerInput.TargetPosition3;
            offer.TargetPosition4 = offerInput.TargetPosition4;

            return offer;
        }
    }
}
