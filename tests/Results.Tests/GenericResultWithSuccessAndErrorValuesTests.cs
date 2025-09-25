namespace Results.Tests;
public class GenericResultWithSuccessAndErrorValuesTests
{
    [Fact]
    public void Ok_ShouldCreateSuccessResult_WithValue()
    {
        // Arrange
        var result = Result<string, string>.Ok("Hola");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal("Hola", result.Value);
    }

    [Fact]
    public void Fail_ShouldCreateFailureResult_WithError()
    {
        // Arrange
        var result = Result<string, string>.Fail("Error fatal");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal("Error fatal", result.Error);
    }

    [Fact]
    public void Match_ShouldReturnSuccessValue_WhenResultIsSuccess()
    {
        // Arrange
        var result = Result<int, string>.Ok(42);

        // Act
        var output = result.Match(
            onSuccess: val => $"Valor: {val}",
            onError: err => $"Error: {err}"
        );

        // Assert
        Assert.Equal("Valor: 42", output);
    }

    [Fact]
    public void Match_ShouldReturnErrorValue_WhenResultIsFailure()
    {
        // Arrange
        var result = Result<int, string>.Fail("No se pudo");

        // Act
        var output = result.Match(
            onSuccess: val => $"Valor: {val}",
            onError: err => $"Error: {err}"
        );

        // Assert
        Assert.Equal("Error: No se pudo", output);
    }

    [Fact]
    public void Match_Action_ShouldInvokeOnSuccess_WhenResultIsSuccess()
    {
        // Arrange
        var result = Result<string, string>.Ok("¡Éxito!");
        string captured = null;

        // Act
        result.Match(
            onSuccess: val => captured = $"OK: {val}",
            onError: err => captured = $"ERROR: {err}"
        );

        // Assert
        Assert.Equal("OK: ¡Éxito!", captured);
    }

    [Fact]
    public void Match_Action_ShouldInvokeOnError_WhenResultIsFailure()
    {
        // Arrange
        var result = Result<string, string>.Fail("Falló");
        string captured = null;

        // Act
        result.Match(
            onSuccess: val => captured = $"OK: {val}",
            onError: err => captured = $"ERROR: {err}"
        );

        // Assert
        Assert.Equal("ERROR: Falló", captured);
    }

    [Fact]
    public void AccessingValueOnFailure_ShouldThrowException()
    {
        var result = Result<string, string>.Fail("Error");

        Assert.Throws<InvalidOperationException>(() => _ = result.Value);
    }

    [Fact]
    public void AccessingErrorOnSuccess_ShouldThrowException()
    {
        var result = Result<string, string>.Ok("Todo bien");

        Assert.Throws<InvalidOperationException>(() => _ = result.Error);
    }

}


