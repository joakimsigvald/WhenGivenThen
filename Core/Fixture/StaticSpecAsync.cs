﻿namespace WhenGivenThen.Fixture;

public abstract class StaticSpecAsync<TResult> : SpecAsync<TResult>
{
    protected override sealed void Instantiate() { }
}