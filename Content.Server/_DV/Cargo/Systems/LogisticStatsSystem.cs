using Content.Server._DV.Cargo.Components;
// using Content.Shared.Cargo; // Frontier
using JetBrains.Annotations;

namespace Content.Server._DV.Cargo.Systems;

public sealed partial class LogisticStatsSystem : EntitySystem // Frontier: SharedCargoSystem<EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();
    }

    [PublicAPI]
    public void AddOpenedMailEarnings(SectorLogisticStatsComponent component, int earnedMoney) // Frontier: remove EntityUid as first arg
    {
        component.Metrics = component.Metrics with
        {
            Earnings = component.Metrics.Earnings + earnedMoney,
            OpenedCount = component.Metrics.OpenedCount + 1
        };
        UpdateLogisticsStats(); // Frontier: remove EntityUid from args
    }

    [PublicAPI]
    public void AddExpiredMailLosses(SectorLogisticStatsComponent component, int lostMoney) // Frontier: remove EntityUid as first arg
    {
        component.Metrics = component.Metrics with
        {
            ExpiredLosses = component.Metrics.ExpiredLosses + lostMoney,
            ExpiredCount = component.Metrics.ExpiredCount + 1
        };
        UpdateLogisticsStats(); // Frontier: remove EntityUid from args
    }

    [PublicAPI]
    public void AddDamagedMailLosses(SectorLogisticStatsComponent component, int lostMoney) // Frontier: remove EntityUid as first arg
    {
        component.Metrics = component.Metrics with
        {
            DamagedLosses = component.Metrics.DamagedLosses + lostMoney,
            DamagedCount = component.Metrics.DamagedCount + 1
        };
        UpdateLogisticsStats(); // Frontier: remove EntityUid from args
    }

    [PublicAPI]
    public void AddTamperedMailLosses(SectorLogisticStatsComponent component, int lostMoney) // Frontier: remove EntityUid as first arg
    {
        component.Metrics = component.Metrics with
        {
            TamperedLosses = component.Metrics.TamperedLosses + lostMoney,
            TamperedCount = component.Metrics.TamperedCount + 1
        };
        UpdateLogisticsStats(); // Frontier: remove EntityUid from args
    }

    private void UpdateLogisticsStats() => RaiseLocalEvent(new LogisticStatsUpdatedEvent()); // Frontier: remove EntityUid from args
}

// Frontier: removed station EntityUid as an argument in LogisticStatsUpdatedEvent
public sealed class LogisticStatsUpdatedEvent : EntityEventArgs
{
    public LogisticStatsUpdatedEvent()
    {
    }
}
