namespace Results.Tests;
public class GenericResultWithSuccessValueTests
{
    [Fact]
    public void Ok_ShouldContainValue_AndBeSuccess()
    {
        // Arrange
        var result = Result<string>.Ok("Hello");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal("Hello", result.Value);
        Assert.Null(result.Error);
        Assert.Null(result.ErrorMessage);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Fail_WithError_ShouldBeFailure()
    {
        // Arrange
        var error = new Error("E002", "Invalid input");
        var result = Result<string>.Fail(error);

        // Assert
        Assert.True(result.IsFailure);
        Assert.False(result.IsSuccess);
        Assert.Equal(error, result.Error);
        Assert.Equal("Invalid input", result.ErrorMessage);
        Assert.Single(result.Errors);
    }

    [Fact]
    public void Fail_WithMessage_ShouldSetErrorMessage()
    {
        // Arrange
        var result = Result<int>.Fail("Calculation failed");

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal("Calculation failed", result.ErrorMessage);
        Assert.Single(result.Errors);
        Assert.Equal("Calculation failed", result.Error.Message);
    }

    [Fact]
    public void Match_ShouldInvokeOnSuccess_WhenResultIsSuccess()
    {
        // Arrange
        var result = Result<int>.Ok(42);

        // Act
        var output = result.Match(
            onSuccess: value => $"Value: {value}",
            onError: r => $"Error: {r.ErrorMessage}"
        );

        // Assert
        Assert.Equal("Value: 42", output);
    }

    [Fact]
    public void Match_ShouldInvokeOnError_WhenResultIsFailure()
    {
        // Arrange
        var result = Result<string>.Fail("Something went wrong");

        // Act
        var output = result.Match(
            onSuccess: value => $"Value: {value}",
            onError: r => $"Error: {r.ErrorMessage}"
        );

        // Assert
        Assert.Equal("Error: Something went wrong", output);
    }

    [Fact]
    public void Match_Action_ShouldInvokeOnSuccess_WhenResultIsSuccess()
    {
        // Arrange
        var result = Result<string>.Ok("Hola");
        string captured = null;

        // Act
        result.Match(
            onSuccess: value => captured = $"Valor: {value}",
            onError: r => captured = $"Error: {r.ErrorMessage}"
        );

        // Assert
        Assert.Equal("Valor: Hola", captured);
    }

    [Fact]
    public void Match_Action_ShouldInvokeOnError_WhenResultIsFailure()
    {
        // Arrange
        var result = Result<string>.Fail("Falló la operación");
        string captured = null;

        // Act
        result.Match(
            onSuccess: value => captured = $"Valor: {value}",
            onError: r => captured = $"Error: {r.ErrorMessage}"
        );

        // Assert
        Assert.Equal("Error: Falló la operación", captured);
    }

}


