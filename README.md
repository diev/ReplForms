# ReplForms
[![Build status](https://ci.appveyor.com/api/projects/status/5si5rlduax254gio?svg=true)](https://ci.appveyor.com/project/diev/replforms)
[![GitHub Release](https://img.shields.io/github/release/diev/ReplForms.svg)](https://github.com/diev/ReplForms/releases/latest)

Replaces every `key[;value;remark;regexp]` in a template XML file with
DataGridView inserted and validated values.

Заменяет каждый `Параметр[:Значение:Примечание:RegExp]` в файле шаблона
(XML или другом) в наглядной сетке с опциональной проверкой введенных
полей на соответствие прилагаемям регулярным выражениям.

![Рабочее окно приложения](docs/assets/images/ReplForms.png)

## Help / Помощь

Шаблон - это XML (или другой) файл,
где есть такие варианты специальных полей шаблона:

    `Параметр'
    `Параметр;Примечание'
    `Параметр;Значение;'
    `Параметр;Значение;Примечание'
    `Параметр;Значение;Примечание;RegExp'

Поле "Значение" (значение по умолчанию) может делать автозамену:
- `GUID`
- `YYYY-MM-DD`

Если поле "Примечание" содержит разделитель `|`, то при клике по строке в
таблице будет возникать контекстное меню из указанных строк пунктов меню,
а при выборе - подставляться. К значениям пунктов меню можно приписывать
пояснение через ` - ` (оно не будет подставлено).

Опция в меню "Заменять все" (включена по умолчанию) - делает замену всех
полей далее с таким же параметром. Если отключить, то одинаковые параметры
будут повторяться в таблице по мере попадания в шаблонах и требовать их
заполнения.

Опциональным параметром запуска можно указать, какой файл шаблона открыть
сразу и опционально следующим - в какой файл сохранить результат:

    [Шаблон [Результат]]

В имени файла можно делать автозамену:

- `{GUID}`
- `{YYYY-MM-DD}`

Опции запуска:

- `-1` - отключить опцию "Заменять все",
- `-1251` - кодировка windows-1251 в текстовых шаблонах.

## Examples / Примеры

В папке [Templates](Templates) есть несколько примеров.

- `_ED462-{YYYY-MM-DD}-1001.xml` - файл в формате УФЭБС ED462;
- `_ССП_Request.xml` - файл запроса в КБКИ (см. транспортную программу
<https://github.com/diev/Api5704>).

## Requirements / Требования

- .NET 8 Desktop Runtime

## Build / Построение

Build this Project with many dlls into a Distr folder:

    dotnet publish Project.csproj -o bin

Build this Project as a single-file app when NET Desktop runtime required:

    dotnet publish Project.csproj -o bin -r win-x64 -p:PublishSingleFile=true --no-self-contained

Build this Project as a single-file app when no runtime required:

    dotnet publish Project.csproj -o bin -r win-x64 -p:PublishSingleFile=true

или используйте прилагаемый `build.cmd` (он построит и резервную копию в
архиве при наличии 7-Zip).

## License / Лицензия

Licensed under the [Apache License, Version 2.0].

[Apache License, Version 2.0]: LICENSE
