# ReplForms
Replaces every `key[:value:remark:regexp]' in a template XML file with DataGridView inserted and validated values.

![Рабочее окно приложения](docs/assets/images/ReplForms.png)

## Help / Помощь

Шаблон - это XML (или другой) файл,
где есть такие варианты специальных полей шаблона:

- `\`Параметр'`
- `\`Параметр;Примечание'`
- `\`Параметр;Значение;'`
- `\`Параметр;Значение;Примечание'`
- `\`Параметр;Значение;Примечание;RegExp'`

Поле ""Значение по умолчанию"" может делать автозамену:
- `GUID`
- `YYYY-MM-DD`

Опция "Заменять все" - сделает одинаковую замену.

Параметры запуска: Шаблон Результат
В имени файла можно делать автозамену:

- `{GUID}`
- `{YYYY-MM-DD}`

- `-all` - опция "Заменять все",
- `-1251` - кодировка windows-1251 в текстовых шаблонах.

## Examples / Примеры

В папке Templates есть несколько примеров.
Для кодировки 1251 (символы не отображаются на сайте) есть параллельный в UTF-8.

## Requirements / Требования

- .NET 8 Desktop Runtime

## Build / Построение

Build this Project with many dlls into a Distr folder  
`dotnet publish Project.csproj -o Distr`

Build this Project as a single-file app when NET Desktop runtime required  
`dotnet publish Project.csproj -o Distr -r win-x64 -p:PublishSingleFile=true --self-contained false`

Build this Project as a single-file app when no runtime required  
`dotnet publish Project.csproj -o Distr -r win-x64 -p:PublishSingleFile=true`

## License / Лицензия

Licensed under the [Apache License, Version 2.0].

[Apache License, Version 2.0]: LICENSE
