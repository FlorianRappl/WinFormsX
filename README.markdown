Windows Forms Extensions
============================================================

The Windows Forms Extensions library has been created to provide elegant and
useful features, which are available in Web technologies or XAML (WPF, ...)
to the Windows Forms technology.

The list of implemented helpers contains methods such as `Animate()`, which
have been implemented using higher possibilities of the C# programming
language (like extension methods or anonymous objects). Included methods
are not limited to the Windows Forms technology (such as extending classes
like `Form` or `Control`), but can also extend the possibilites of the
.NET-Framework.

If you are willing to contribute to this project (either with new ideas or
existing codes), you are more than welcome.

Current status
-------------------------------------------------------

The current version number is **0.1.0**. This is the first version and is an
incomplete alpha build. A NuGet package is available. The package can be found
over the Package Manager or the [NuGet Website](https://www.nuget.org/packages/WinFormsX).

Version history
-------------------------------------------------------

**0.1.0:**

- Extension methods for the `Graphics` object (`DrawRoundRectangle()`, `DrawShadow()`, `DrawReflection()`, `DrawImageSmooth()`)
- Extension method for the `GraphicPath` object (`AddRoundRectangle()`)
- Extension methods for the `Image` object (`FindDominantColor()`, `Resize()`, `GetGrayScaleVersion()`)
- Extension methods for the `Uri` object (`Request()`, `JsonRequest()`)
- Extension methods for the `Control` object (`Animate()`, `Shadow()`)

Benefits of using WinFormX
-------------------------------------------------------

- Included animations
- More dynamic applications
- Forms with different designs and extended possibilities
- More options included in GDI+
- Selectors and various helpers
- Useful (but mostly unknown) API function calls have been included

Participating in the project
-------------------------------------------------------

If you know some feature that Windows Forms is currently missing, and you
are willing to implement the feature (or have already implemented it), then
your contribution is more than welcome!

Currently implemented methods
-------------------------------------------------------

Here will be some text about already implemented methods and links to obtain further information.
Some information can be found on the [official webpage](http://winformx.florian-rappl.de/index.html).

Some legal stuff
------------------

Copyright (c) 2012, Florian Rappl

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
