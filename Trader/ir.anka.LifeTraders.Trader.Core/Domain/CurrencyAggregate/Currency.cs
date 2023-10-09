using Castle.Core.Internal;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Enums;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Exceptions;

namespace ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;

public class Currency : EntityBase, IAggregateRoot<Currency>
{
    private readonly ICurrencyValidator currencyValidator;

    public Currency(string title, string iso, string symbol, CurrencyType currencytype, int order, ICurrencyValidator currencyValidator)
    {
        Id = Guid.NewGuid();
        Title = title;
        Iso = iso;
        Symbol = symbol;
        Order = order;
        this.currencyValidator = currencyValidator;
        Type = currencytype;
        Validate();
    }

    protected Currency()
    {
    }

    public string Title { get; private set; } = string.Empty;

    private string iso = string.Empty;

    public string Iso { get => iso; private set => iso = value.ToUpper(); }

    public string Symbol { get; private set; } = string.Empty;

    public int Order { get; private set; } = 0;

    public CurrencyType Type { get; private set; }

    public void Validate()
    {
        var validateConditionsResult = ValidateConditions();

        if (!validateConditionsResult.IsNullOrEmpty())
        {
            throw new CurrencyValidateException(validateConditionsResult);
        }
    }

    private IEnumerable<Exception> ValidateConditions()
    {
        if (string.IsNullOrEmpty(Title))
        {
            yield return new PropertyNullOrEmptyException(nameof(Title));
        }

        if (string.IsNullOrEmpty(Iso))
        {
            yield return new PropertyNullOrEmptyException(nameof(Iso));
        }

        if (string.IsNullOrEmpty(Symbol))
        {
            yield return new PropertyNullOrEmptyException(nameof(Symbol));
        }
    }
}