# wwwroot/lib

Složka pro knihovny třetích stran (Bootstrap, jQuery, jQuery Validation).

Aktuálně se knihovny načítají z CDN (jsdelivr) – viz `Views/Shared/_Layout.cshtml`
a `Views/Shared/_ValidationScriptsPartial.cshtml`, takže tu nic být nemusí.

Pokud je chcete mít lokálně (např. bez internetu), stáhněte je přes LibMan:

```
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
libman install bootstrap@5.3.3 --provider jsdelivr --destination wwwroot/lib/bootstrap
libman install jquery@3.7.1 --provider jsdelivr --destination wwwroot/lib/jquery
```

a v `_Layout.cshtml` změňte odkazy na `~/lib/...`.
