using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using TheatricalPlayersRefactoringKata.Application;
using TheatricalPlayersRefactoringKata.Application.Services;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Enums;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class StatementPrinterTests
{
    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestStatementExampleLegacy()
    {
        var plays = new Dictionary<string, Play>();
        plays.Add("hamlet", new Play("Hamlet", 4024, Genre.Tragedy));
        plays.Add("as-like", new Play("As You Like It", 2670, Genre.Comedy));
        plays.Add("othello", new Play("Othello", 3560, Genre.Tragedy));

        Invoice invoice = new Invoice(
            "BigCo",
            new List<Performance>
            {
                new Performance("hamlet", 55),
                new Performance("as-like", 35),
                new Performance("othello", 40),
            }
        );

        var statementFormatter = new TextStatementFormatter();
        var statementPrinter = new StatementPrinter(statementFormatter);
        var result = statementPrinter.Print(invoice, plays);

        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestTextStatementExample()
    {
        var plays = new Dictionary<string, Play>
        {
            { "hamlet", new Play("Hamlet", 4024, Genre.Tragedy) },
            { "as-like", new Play("As You Like It", 2670, Genre.Comedy) },
            { "othello", new Play("Othello", 3560, Genre.Tragedy) },
            { "henry-v", new Play("Henry V", 3227, Genre.History) },
            { "john", new Play("King John", 2648, Genre.History) },
            { "richard-iii", new Play("Richard III", 3718, Genre.History) }
        };

        Invoice invoice = new Invoice(
            "BigCo",
            new List<Performance>
            {
                new Performance("hamlet", 55),
                new Performance("as-like", 35),
                new Performance("othello", 40),
                new Performance("henry-v", 20),
                new Performance("john", 39),
                new Performance("henry-v", 20)
            }
        );

        var statementFormatter = new TextStatementFormatter();
        var statementPrinter = new StatementPrinter(statementFormatter);
        var result = statementPrinter.Print(invoice, plays);

        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestXmlStatementExample()
    {
        var plays = new Dictionary<string, Play>
        {
            { "hamlet", new Play("Hamlet", 4024, Genre.Tragedy) },
            { "as-like", new Play("As You Like It", 2670, Genre.Comedy) },
            { "othello", new Play("Othello", 3560, Genre.Tragedy) },
            { "henry-v", new Play("Henry V", 3227, Genre.History) },
            { "john", new Play("King John", 2648, Genre.History) },
            { "richard-iii", new Play("Richard III", 3718, Genre.History) }
        };

        var invoice = new Invoice(
            "BigCo",
            new List<Performance>
            {
                new Performance("hamlet", 55),
                new Performance("as-like", 35),
                new Performance("othello", 40),
                new Performance("henry-v", 20),
                new Performance("john", 39),
                new Performance("henry-v", 20)
            }
        );

        var statementFormatter = new XmlStatementFormatter();
        var statementPrinter = new StatementPrinter(statementFormatter);
        var result = statementPrinter.Print(invoice, plays);

        Approvals.Verify(result);
    }
}
