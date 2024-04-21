# TagScanner - Overview {#contents}

TagScanner gathers ID3 tags and other available metadata from suitable files, e.g. MP3s, and stores them in a library file. Loaded metadata are editable, and when the library is re-saved, these edits can optionally be applied to the relevant media files.

A query builder is provided to allow the construction of complex filters based on all metadata properties.

A Find/Replace function operates across multiple tags, and optionally uses Regex.

The app is WinForms based, but uses embedded WPF grids to take advantage of their (free!) filtering, sorting and grouping operations.

This document first describes the basic operation of the app from a user perspective, then presents brief desciptions of the most important classes and other design elements of TagScanner.

## Contents

- <a href="#userguide"><b>User Guide</b></a>
  - <a href="#filenew">Creating a New Library</a>
  - <a href="#addmedia">Adding Media Files to a Library</a>
  - <a href="#edittags">Editing Tags</a>
- <a href=""><b>Code Reference</b></a>
  - <a href="#model">Model</a>
    - <a href="#tags">Tags</a>
    -  <a href="#itrack">_ITrack (interface)_</a>
        - <a href="#track">Track</a>
        - <a href="#selection">Selection</a>
  - <a href="#term">_Term (abstract)_</a>
    - <a href="#constant">Constant</a>
    - <a href="#field">Field</a>
    - <a href="#param">Parameter</a>
    - <a href="#termlist">TermList</a>
      - <a href="#cast">Cast</a>
      - <a href="#function">Function</a>
      - <a href="#operation">Operation</a>
        - <a href="#monad">Monadic Operation ( + - !</a> )
        - <a href="#dyad">Dyadic Operation ( + - * / &amp; | \^ = ≠ &lt; ≤ ≥ &gt; )</a>
        - <a href="#triad">Triadic Operation ( ? : )</a>
  - <a href="#grammar">Grammar</a>
    - <a href="#tokenizer">Tokenizer</a>
    - <a href="#parser">Parser</a>
    - <a href="#parserstate">ParserState</a>
  - <a href="#dcs">Development Cheat Sheet</a>
    - <a href="#cstags">Tags</a>
    - <a href="#csfields">Fields</a>
    - <a href="#csfuncs">Functions</a>
    - <a href="#csops">Operations</a>

## User Guide {#userguide}

## Creating a New Library {#filenew}

When run, the app starts up with a new, empty library displayed, ready to add media files and/or folders. Later, when you have created and saved a library file, you can begin work on another by using the _File|New_ command to create a new, empty library.

If the app window already contains a library which has not yet been saved (as indicated by a \* in the window caption bar), you will be prompted to do so:

<img src="docs/file modified.png">

Answer _Yes_ to save the existing library file, _No_ to discard it, or _Cancel_ to continue working on the existing library (cancelling the _File|New_ command).

Another way to begin work on a new library, _without_ interrupting work on an existing one, is to use the _Window|New_ rather than _File|New_ command. This will simply create a new, empty copy of the app window. You may have any number of such windows open simultaneously, and switch between them using Alt+Tab.

## Adding Media Files to a Library {#addmedia}

The main methods of adding media files to a library are with the _Add|Media_ and _Add|Folder_ commands. Assuming a well ordered and curated media file collection, for example under a single folder (perhaps with subfolders for each artist, then each album), the _Add|Media_ command will be used much less frequently than the mighty, directory-traversing _Add|Folder_ command.

_Add|Media_ lets you browse for individual media files, or groups of these under a common directory, and add them individually to the library. Notice the file type filter in the bottom right corner of this dialog, which is currently set to "Audio Files". This filter controls which types of files will be added to the library - not just here, but across the app.

<img src="docs/add media.png">

_Add|Folder_ lets you browse for a folder in the file system directory structure, and add all the relevant media files to the library, including all files in nested subfolders, sub-subfolders, etc.

<img src="docs/add folder.png">

The file types added will be controlled by the filter selected in the _Add|Media_ dialog, so it might be worth visiting that command, just to set this - for example, if you would like music video files to be included along with the audio files.

## Editing Tags {#edittags}

The main purpose of TagScanner is to make the maintenance of media metadata tags convenient and easy. Several tools are provided for this purpose. Tags can be edited in either the main table area of the app window, or in the properties pane at the bottom right, which can conveniently display far mode property tags simultaneously than the main table.

Tags which are readonly appear in a greyed font, while those which can be edited are shown in black text.

## Model {#model}

The __Model__ class represents the collection of _data items_ (also known as _business objects_) used by the application.

<a href="#contents">\^Contents</a>

## Tag {#tags}

The __Tag__ enumeration lists just the names of all the properties of a __Track__ which may be interrogated. Values from this enumeration, rather than property names, are used to refer to these properties in code (enumerations being more efficient than strings).

Note that these values are generally hidden form the user, who instead will see their chosen DisplayName values in the UI. For example, the user will access a __Track__'s _Artist_, rather than the underlying _JoinedPerformers_ property.

<a href="#contents">\^Contents</a>

## ITrack (interface) {#itrack}

The __ITrack__ interface lists all the names and types of the tag and other metadata properties of a __Track__. This interface is of course implemented by the __Track__ class, but also by the __Selection__ class, where it gives information about the combined properties of a list of __Track__ objects.

<a href="#contents">\^Contents</a>

## Track {#track}

<a href="#contents">\^Contents</a>

## Selection {#selection}

The __Selection__ class is the main unit of transport for __Track__  lists being passed between the various models, views, controllers and commands in the general operation of the app. Its most important property is __Tracks__, the list of __Track__ objects that it references.

The unit of persistence in the app is _not_ the __Selection__, but the __List&lt;Track&gt;__. Whenever a list of tracks is being saved to a file, exported as XML, copied to the clipboard etc., it is the raw __List&lt;Track&gt;__ object, and not their enclosing __Selection__, which is used to transfer them.

<a href="#contents">\^Contents</a>

## Term (abstract) {#term}

The __Term__ class is the abstract base of the following hierarchy:

- ___Term__ (abstract)_
  - <a href="#constant">__Constant__</a>
  - <a href="#field">__Field__</a>
  - <a href="#param">__Parameter__</a>
  - <a href="#termlist">__TermList__</a>
    - <a href="#cast">__Cast__</a>
    - <a href="#function">__Function__</a>
    - <a href="#operation">__Operation__</a>

These and several other related classes and types are grouped together under the _TagScanner.Terms_ namespace, distinct from the _TagScanner.Models_ namespace in general use up to this point in the document.

<a href="#contents">\^Contents</a>

## Constant {#constant}

The __Constant__ class represents fixed values in expressions. Supported value types are _bool_, _char_, _string_, various numerical integer (_int_, _uint_, _long_, _ulong_) and floating point (_float_, _double_, _decimal_) formats, together with _TimeSpan_ and _DateTime_.

<a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Field {#field}

The __Field__ class represents domain item properties. This system was developed primarily to maintain the ID3 tags of a collection of audiovisual media, chiefly MP3 music files, so examples of fields are _Title_, _Duration_, _Album Title_, etc., or file properties such as _File Attributes_, or _File Created_.

Notice that field denotations are permitted to contain spaces and other non-alphanumeric characters.

At runtime, the full list of accessible fields, together with their various metadata, will be assembled from the attributes attached to properties in the _Selection_ class. This is so for historical reasons; the first UI developed for the application used the Winforms PropertyGrid control, which binds to these attributes. The next stage of development will include moving these into readily available storage, free of recompilation requirements.

<a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Parameter {#param}

The __Parameter__ class is used internally, to provide the default parameter values needed while building expressions manually.

<a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## TermList {#termlist}

The __TermList__ class is represents multiterm collections.

- __TermList__
  - <a href="#cast">__Cast__</a>
  - <a href="#function">__Function__</a>
  - <a href="#operation">__Operation__</a>

<a href="#termlist">\^TermList</a> <a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Cast {#cast}

The __Cast__ class is the simplest __TermList__ descendant. Taking a single operand, it recasts its ResultType to be some other, compatible new type. For example, the expression

    # Album Artists.Cast(long)

converts the _# Album Artists_ property from a normal integer (System.Int32) to a long one (System.Int64).

<a href="#termlist">\^TermList</a> <a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Function {#function}

The __Function__ rclass epresents a C# method call, taking one __Term__ per required function argument, and returning a new __Term__ whose ResultType matches that method's return type.

Syntactically there are two varieties of __Function__, _static_ and _member_. An example of a _static_ __Function__ is _Compare_:

    Compare(1st Album Artist, "N")

This compares the value of an item's _1st Album Artist_ property to the fixed value _"N"_, and returns a __Constant Term__ representing the usual result of performing a static _Compare_ method between two strings - in this case, indicating whether the artist would appear in the first or second half of a dictionary.

By contrast, an example of a _member_ __Function__ might be

    Album Artists (joined).Contains("Beat")

which, in the case of a Beatles song, would return a __Constant Term__ with a _ResultType_ of _bool_, and a _Value_ of _true_.

The available roster of __Function__s is currently found in the _Methods.cs_ file, though the next stage of development will include moving these into readily available storage, free of recompilation requirements.

<a href="#contents">\^Contents</a> <a href="#term">\^Term</a> <a href="#termlist">\^TermList</a>

## Operation {#operation}

The __Operation__ class represents a C# operator call, taking one or more __Term__s, applying an __Operator__ to them, and yielding a result __Term__. The currently available set includes monadic and dyadic operators, and one triadic sample. Although several subclasses are provided for various (not all) of the available operations, there are no specific base classes for monadic & dyadic types.

The available __Operator__ set is currently found in the _Operators.cs_ file, though the next stage of development will include moving these into readily available storage, free of recompilation requirements.

<a href="#termlist">\^TermLiat</a> <a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Monadic Operation ( + - ! ) {#monad}

The available __Monadic Operator__ set includes _unary plus (+)_, _negative (-)_, and _logical negation (!)_.

- __Operation__
  - __Positive__
  - __Negative__
  - __Negation__

Each of these has its own specialized __Operation__ subclass, __Positive__, __Negative__ and __Negation__ respectively, although they can equally be instantiated using just the __Operation__ base class and supplying the appropriate __Operator__ symbol.

<a href="#operation">\^Operation</a> <a href="#termlist">\^TermList</a> <a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Dyadic Operation ( + - * / &amp; | \^ = ≠ &lt; ≤ ≥ &gt; ) {#dyad}

The classes in this category are labelled dyadic, not because they take exactly two operands, but rather because their underlying C# operators are themselves strictly dyadic. However, many of these __Operation__ subclasses can accept any number of operands. This freedom should be used carefully, and only when the precedence & associativity context is clear.

The following is not a complete dyadic __Operation__ list, since several of them, such as the equalities ('=', '≠') and the relationals ('<', '≤', '≥', '>'), do not have their own dedicated subclasses.

- __Operation__
  - __Sum__
  - __Difference__
  - __Product__
  - __Quotient__
  - __Conjunction__
  - __Disjunction__
  - __Concatenation__

For example, the sum of 1+2+3 can be coded as any of the following:

    new Sum(new Sum(1, 2), 3) // Nested dyads.

    new Sum(1, new Sum(2, 3)) // Nested dyads.

    new Sum(1, 2, 3) // Effectively triadic or n-adic.

    new Operation('+', 1, 2, 3) // Operation subclasses like Sum are just a coding convenience.

    new Operation(1, '+', 2, 3) // Infix operators can be moved to 2nd position in the parameter list.

Note that implicit type conversion operators are invoked behind the scenes in these examples, to convert the supplied numerical values into the __Constant__ instances expected by an __Operation__, as well as in the last example, converting the '+' character to the required _enum_ value __Op.Add__.

As another example, the removal of the 2-term restriction on these operators makes implementation of a "between" operator easy:

    new Operation('<', 1, 2, 3) // Returns true, since 1 < 2 < 3.

Under the hood, this is implemented as a __Conjunction__ of _1 &lt; 2_ and _2 &lt; 3_.

<a href="#operation">\^Operation</a> <a href="#termlist">\^TermList</a> <a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Grammar {#grammar}

<details><summary>The grammar of the TagScanner application's scripting language looks a little bit like this <i>(<u>click here</u> to expand / collapse):</i></summary>

- __Term:__
  - Cast | Constant | Field | Function | Operation
  - ( Term )

- __Cast:__
  - ( Type ) Term

- __Type:__
  - bool | byte | char | DateTime | decimal | double | float | int | long | object | sbyte | short | string | TimeSpan | uint | ulong | ushort

- __Constant:__
  - Number | Char | String

- __Number:__
  - [-+]?[0-9]+

- __Char:__
  - '([\^']|'')'

- __String:__
  - "([\^\"]|\.)*"

- __Field:__
  - Album | Album Artists | # Album Artists | ... | Year

- __Function:__
  - StaticFunction ( TermList? )
  - Term . MemberFunction ( TermList? )

- __MemberFunction:__
  - Contains | EndsWith | ... | Uppercase

- __StaticFunction:__
  - Compare | Format | ... | Replace$ | ... | Truncate

- __TermList:__
  - Term
  - Term , TermList

- __Operation:__
  - Operator1 Term
  - Term Operator2 Term
  - Term ? Term : Term

- __Operator1:__ _one of_ + - !

- __Operator2:__ _one of_ &amp; | \^ = ≠ &lt; ≤ ≥ &gt; + - * /

</details>

<a href="#contents">\^Contents</a>

## Tokenizer {#tokenizer}

The __Tokenizer__ class performs the first stage of expression parsing, separating the input character stream into its various recognisable language tokens.

<a href="#contents">\^Contents</a>

## Parser {#parser}

The __Parser__ class, leaning heavily on the resources of the __Tokenizer__ class, implements <a href="https://en.wikipedia.org/wiki/Recursive_descent_parser">recursive descent</a> to convert the input character stream into an executable expression. Its two main public methods are _Parse_ and _TryParse_.

While broadly following the C# rules of operator precedence and associativity, as well as the language's conventions for type safety, literal values and method calls, the Parser does however allow some flexibility in certain areas of syntax:

  - The names of static and member methods, operators, and track properties, are always case-insensitive.
  - User entered data can be treated as case-sensitive or not, for the purposes of any individual query.
  - Static methods are invoked without a qualifying class name, e.g.

        Compare(Artist, "N")

    rather than

        string.Compare(Artist, "N");

  - The dot operator, used to indicate member method calls, is optional.
  - Parentheses are optional in method calls taking zero or one parameters.

So, the following pairs are equivalent:

    Album.Contains("Pepper")
    Album contains "pepper"

    Album.Length() > 0
    album length > 0

Numeric and other literal constants generally use C# syntax, including apostrophes and quotation marks for character and string constants respectively, and the usual type suffixes for integers, longs, doubles, and so on. An exception is made for TimeSpan and DateTime values, which have a standard format easily recognised by inclusion in square brackets.

<a href="#contents">\^Contents</a>

## ParserState {#parserstate}

Class __ParserState__ isolates the steps of the parsing process from the messy details of its mechanical implementation, allowing its major steps to be targeted with special debugging tools, and so followed much more easily.

The essential operation of Recursive Descent Parsing is beautiful to watch. This class allows the capture of each Push, Pop, Enqueue and Dequeue action, and the display of the contents of the three chief dynamic data structures in play: the _Tokens_ queue, and the _Terms_ and _Operators_ stacks.

In Visual Studio's _Output_ window, choose _Show output from: Debug_, then right-click in the window and deselect all _Messages_ except _Program Output_. Annoyingly, this has to be done for each available Message type individually!

To get these internal state data dumps to appear at runtime, define the conditional compilation symbol _DEBUG_PARSER_.

<a href="#contents">\^Contents</a>

## Development Cheat Sheet {#dcs}

### __Tags__ {#cstags}

- This application uses the _TagLib#_ library to access (both read and write) metadata in media files, including video, audio, and photo formats.
  - In the _TagLib#_ library source code and API, the term _Tag_ refers to a structure containing most of the metadata for the given media.
  - By contrast, the term _Tag_ in this application means any single item of metadata from that structure, e.g. track title, performer, duration, etc.
  - These _Tags_ have in turn their own metadata, indicating for example their runtime type, category, and so on.
  - Such _meta-metadata_ can be found in the _TagScanner.Models.TagInfo_ class _(TagInfo.cs)_.
- In the application source code, __Tag__ values are introduced in the _TagScanner.Models.Tag_ enumeration _(Tags.cs)_.
  - __Tag__ data types and read/write permissions are best summarised in the _TagScanner.Models.ITrack_ interface _(ITrack.cs)_.
  - The set of possible __Tag__ data type names is supplied by the static _TagScanner.Models.TagType_ class _(TagType.cs)_.
  - This interface is implemented by two classes in the _TagScanner.Models_ namespace: _Track (Track.cs)_ and _Selection (Selection.cs)_.
- The code level name of a __Tag__ is not exposed in the app UI, nor in the scripting interface. Instead, its _DisplayText_ value is used throughout.
  - For historical reasons, these values appear as attributes on corresponding properties of the _TagScanner.Models.Selection_ class _(Selection.cs)_.
  - To see all __Tag__ _DisplayText_ values: (1) run the app, (2) right-click _Select Columns_ or _Select Tags_, then (3) choose _List | Names only_.

<a href="#contents">\^Contents</a>

### __Fields__ {#csfields}

- Available __Field__ instances are defined by a _Dictionary<Tag, TagInfo>_ called _TagDictionary_ in the static class _TagScanner.Terms.Tags_.
- The dictionary exposes two arrays as properties of this static class: _Tag[] Keys_, and _TagInfo[] Values_.
- You may use the extension method _TagInfo(this Tag tag)_ toaccess the __Field__ metadata for a given _tag_:

      var tagInfo = tag.TagInfo();

- However, further extension methods are provided to access any other TagInfo member directly, given just the _tag_:

      var category = tag.Category();
      var column = tag.Column(); // Width, Alignment & editor type (Text or CheckBox).
      var displayName = tag.DisplayName();

<a href="#contents">\^Contents</a>

### __Functions__ {#csfuncs}

- Available __Function__ instances are defined by a _Dictionary<Fn, FnInfo>_ called _FunctorDictionary_ in the static class _TagScanner.Terms.Functors_.
- The dictionary exposes two arrays as properties of this static class: _Fn[] Keys_, and _FnInfo[] Values_.
- You may use the extension method _Functors.FnInfo(this Fn fn)_ to access the __Function__ metadata for a given _fn_:

      var fnInfo = fn.FnInfo();

<a href="#contents">\^Contents</a>

### __Operations__ {#csops}

- Available __Operation__ instances are defined by a _Dictionary<Op, OpInfo>_ called _OperatorDictionary_ in the static class _TagScanner.Terms.Operators_.
- The dictionary exposes two arrays as properties of this static class: _Op[] Keys_, and _OpInfo[] Values_.
- You may use the extension method _Operators.OpInfo(this string key)_ to access the __Operation__ metadata for a given operator _op_:

      var opInfo = op.OpInfo();

<a href="#contents">\^Contents</a>
