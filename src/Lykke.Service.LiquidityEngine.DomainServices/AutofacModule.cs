using Autofac;
using JetBrains.Annotations;
using Lykke.Service.LiquidityEngine.Domain.Services;
using Lykke.Service.LiquidityEngine.DomainServices.AssetPairLinks;
using Lykke.Service.LiquidityEngine.DomainServices.Audit;
using Lykke.Service.LiquidityEngine.DomainServices.Balances;
using Lykke.Service.LiquidityEngine.DomainServices.Exchanges;
using Lykke.Service.LiquidityEngine.DomainServices.Instruments;
using Lykke.Service.LiquidityEngine.DomainServices.OrderBooks;
using Lykke.Service.LiquidityEngine.DomainServices.Positions;
using Lykke.Service.LiquidityEngine.DomainServices.Reports;
using Lykke.Service.LiquidityEngine.DomainServices.Settings;
using Lykke.Service.LiquidityEngine.DomainServices.Timers;
using Lykke.Service.LiquidityEngine.DomainServices.Trades;

namespace Lykke.Service.LiquidityEngine.DomainServices
{
    [UsedImplicitly]
    public class AutofacModule : Module
    {
        private readonly string _instanceName;
        private readonly string _walletId;

        public AutofacModule(
            string instanceName,
            string walletId)
        {
            _instanceName = instanceName;
            _walletId = walletId;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AssetPairLinkService>()
                .As<IAssetPairLinkService>()
                .SingleInstance();

            builder.RegisterType<BalanceOperationService>()
                .As<IBalanceOperationService>()
                .SingleInstance();

            builder.RegisterType<BalanceService>()
                .As<IBalanceService>()
                .SingleInstance();

            builder.RegisterType<CreditService>()
                .As<ICreditService>()
                .SingleInstance();

            builder.RegisterType<SettlementService>()
                .As<ISettlementService>()
                .SingleInstance();

            builder.RegisterType<LykkeExchangeService>()
                .As<ILykkeExchangeService>()
                .SingleInstance();
            
            builder.RegisterType<ExternalExchangeService>()
                .As<IExternalExchangeService>()
                .SingleInstance();
            
            builder.RegisterType<InstrumentService>()
                .As<IInstrumentService>()
                .SingleInstance();

            builder.RegisterType<PositionService>()
                .As<IPositionService>()
                .SingleInstance();
            
            builder.RegisterType<SummaryReportService>()
                .As<ISummaryReportService>()
                .SingleInstance();

            builder.RegisterType<OrderBookService>()
                .As<IOrderBookService>()
                .SingleInstance();
            
            builder.RegisterType<QuoteService>()
                .As<IQuoteService>()
                .SingleInstance();
            
            builder.RegisterType<SettingsService>()
                .As<ISettingsService>()
                .WithParameter(new NamedParameter("instanceName", _instanceName))
                .WithParameter(new NamedParameter("walletId", _walletId))
                .SingleInstance();

            builder.RegisterType<TimersSettingsService>()
                .As<ITimersSettingsService>()
                .SingleInstance();
            
            builder.RegisterType<QuoteTimeoutSettingsService>()
                .As<IQuoteTimeoutSettingsService>()
                .SingleInstance();
            
            builder.RegisterType<BalancesTimer>()
                .AsSelf()
                .SingleInstance();
            
            builder.RegisterType<MarketMakerTimer>()
                .AsSelf()
                .SingleInstance();
            
            builder.RegisterType<HedgingTimer>()
                .AsSelf()
                .SingleInstance();
            
            builder.RegisterType<TradeService>()
                .As<ITradeService>()
                .SingleInstance();
            
            builder.RegisterType<MarketMakerService>()
                .As<IMarketMakerService>()
                .SingleInstance();
            
            builder.RegisterType<HedgeService>()
                .As<IHedgeService>()
                .SingleInstance();
        }
    }
}