# _ʞɯɾ_ (pronounced _your_) Scripting Language  
  
The TagScanner7 app uses _ʞɯɾ_ scripting language to help interrogate and maintain ID3v2 metadata tags on audiovisual media files. So what is _ʞɯɾ_ language? Let's look at an example.  
  
    Artist = "The Beatles"  
    and (Album.StartsWith("Sgt. Pepper's") or Album.Contains("Beatles"))  
    and Title.Contains("Love")  
    and Decade = "1960s"  
  
Simple _ʞɯɾ_ filters like this are built from predefined tag _field_ names (**Artist**, **Album**, **Title**, etc.), _constant_ values (e.g. character strings "The Beatles", "Sgt. Pepper's"), _functions_ (**Contains**, **StartsWith**), and connecting _operator_ symbols like +, -, *, /, =, **and**, **or**, **not**.  
  
To see the scope/power of _ʞɯɾ_ language, it helps to get an overview of its structure. Step one: _ʞɯɾ_ _syntax_.  
  
- _ʞɯɾ_ _program_ is a single _block_ (sequence of _compounds_);  
- a _compound_ is a sequence of _terms_, separated by _binary-operators_;  
- a _term_ is... actually, let's have the grammar speak for itself:  
  
## _ʞɯɾ_ Language Syntax  
  
_program_ = _block_  
_block_ = \{ _compound_ \{ _separator_ _compound_ ... \} \}  
_compound_ = _term_ \{ _binary-operator_ _term_ ... \}  
_term_ = \{ _unary-operator_ | _cast_ ... \} _value_ | lparen _block_ rparen \{ \{ dot \} _function_ ... \}  
_cast_ = lparen _type_ rparen  
_value_ = _constant_ | _default_ | _field_ | _function_ | _parameter_ | _variable_  
  
_constant_ = _bool_ | _char_ | _datetime_ | _decimal_ | _double_ | _float_ | _int_ | _long_ | _string_ | _timespan_ | _uint_ | _ulong_ <sup>_(1,3)_</sup>  
_default_ = lbrace _type_ rbrace  
_field_ = _one of_ **Album**, **Artist**, **Duration**, **Title**, **Track #**, ..., **Year/Album** <sup>_(1)_</sup>  

<details><summary><i>Click here for the full list of available fields.</i></summary>  
<b>Album</b><br>
<b>Album Artist</b><br>
<b>Album Artists</b><br>
<b># Album Artists</b><br>
<b>Album Artists (sorted)</b><br>
<b># Album Artists (sorted)</b><br>
<b>Album Gain</b><br>
<b>Album Peak</b><br>
<b>Album (sort by)</b><br>
<b>Amazon ID</b><br>
<b>Artist</b><br>
<b>Artists</b><br>
<b># Artists</b><br>
<b>Artists (joined)</b><br>
<b>Audio Bit Rate</b><br>
<b># Audio Channels</b><br>
<b>Audio Sample Rate</b><br>
<b>BPM</b><br>
<b>Bits Per Sample</b><br>
<b>Century</b><br>
<b>Classical?</b><br>
<b>Codecs</b><br>
<b>Comments</b><br>
<b>Composer</b><br>
<b>Composers</b><br>
<b># Composers</b><br>
<b>Composers (sorted)</b><br>
<b># Composers (sorted)</b><br>
<b>Conductor</b><br>
<b>Copyright</b><br>
<b>Decade</b><br>
<b>Disc #</b><br>
<b>Disc # of #</b><br>
<b>Disc & Track #</b><br>
<b># Discs</b><br>
<b>Duration</b><br>
<b>Empty?</b><br>
<b>File Attributes</b><br>
<b>File Created</b><br>
<b>File Created (UTC)</b><br>
<b>File Extension</b><br>
<b>File Accessed</b><br>
<b>File Accessed (UTC)</b><br>
<b>File Modified</b><br>
<b>File Modified (UTC)</b><br>
<b>File Name</b><br>
<b>File Name (no ext)</b><br>
<b>File Path</b><br>
<b>File Size</b><br>
<b>File Status</b><br>
<b>First Album Artist</b><br>
<b>First Album Artist (sorted)</b><br>
<b>First Artist</b><br>
<b>First Composer</b><br>
<b>First Composer (sorted)</b><br>
<b>First Genre</b><br>
<b>First Performer</b><br>
<b>First Performer (sorted)</b><br>
<b>Genre</b><br>
<b>Genres</b><br>
<b># Genres</b><br>
<b>Grouping</b><br>
<b>Image Altitude</b><br>
<b>Image Creator</b><br>
<b>Image Date/Time</b><br>
<b>Image Exposure Time</b><br>
<b>Image 'F' Number</b><br>
<b>Image Focal Length</b><br>
<b>Image Focal Length (35mm)</b><br>
<b>Image ISO Speed</b><br>
<b>Image Keywords</b><br>
<b>Image Latitude</b><br>
<b>Image Longitude</b><br>
<b>Image Make</b><br>
<b>Image Model</b><br>
<b>Image Orientation</b><br>
<b>Image Rating</b><br>
<b>Image Software</b><br>
<b>Invariant End Position</b><br>
<b>Invariant Start Position</b><br>
<b>Lyrics</b><br>
<b>Media Description</b><br>
<b>Media Types</b><br>
<b>Millennium</b><br>
<b>Mime Type</b><br>
<b>MusicBrainz Artist ID</b><br>
<b>MusicBrainz Disc ID</b><br>
<b>MusicBrainz Release Artist ID</b><br>
<b>MusicBrainz Release Country</b><br>
<b>MusicBrainz Release ID</b><br>
<b>MusicBrainz Release Status</b><br>
<b>MusicBrainz Release Type</b><br>
<b>MusicBrainz Track ID</b><br>
<b>MusicIP PUID</b><br>
<b>Performers</b><br>
<b># Performers</b><br>
<b>Performers (joined, sorted)</b><br>
<b>Performers (sorted)</b><br>
<b># Performers (sorted)</b><br>
<b>Photo Height</b><br>
<b>Photo Quality</b><br>
<b>Photo Width</b><br>
<b>Pictures</b><br>
<b># Pictures</b><br>
<b>Possibly Corrupt?</b><br>
<b>Tag Types</b><br>
<b>Tag Types on Disk</b><br>
<b>Title</b><br>
<b>Title (sort by)</b><br>
<b># Tracks</b><br>
<b>Track Gain</b><br>
<b>Track #</b><br>
<b>Track # of #</b><br>
<b>Track Peak</b><br>
<b>Video Height</b><br>
<b>Video Width</b><br>
<b>Year</b><br>
<b>Year/Album</b><br>
</details>  

_function_ = _function-name_ \{ _term_ | lparen \{ _block_ \} rparen \}  
_parameter_ = **Track** <sup>_(2)_</sup>  
_variable_ = _(any unreserved word)_ <sup>_(1)_</sup>  
  
_function-name_ = _one of_ **Compare**, **Concat**, ..., **Upper** <sup>_(2)_</sup>  

<details><summary><i>Click here for the full list of available functions.</i></summary>  
<b>Compare</b><br>
<b>Concat</b><br>
<b>Contains</b><br>
<b>ContainsX</b><br>
<b>Count</b><br>
<b>CountX</b><br>
<b>Empty</b><br>
<b>EndsWith</b><br>
<b>EndsWithX</b><br>
<b>Equals</b><br>
<b>EqualsX</b><br>
<b>Format</b><br>
<b>If</b><br>
<b>IndexOf</b><br>
<b>IndexOfX</b><br>
<b>Insert</b><br>
<b>Join</b><br>
<b>LastIndexOf</b><br>
<b>LastIndexOfX</b><br>
<b>Length</b><br>
<b>Lower</b><br>
<b>Max</b><br>
<b>Min</b><br>
<b>Pow</b><br>
<b>Remove</b><br>
<b>Replace</b><br>
<b>ReplaceX</b><br>
<b>Round</b><br>
<b>Sign</b><br>
<b>StartsWith</b><br>
<b>StartsWithX</b><br>
<b>Substring</b><br>
<b>ToString</b><br>
<b>Trim</b><br>
<b>Truncate</b><br>
<b>Upper</b><br>
</details>

_unary-operator_ = _one of_ +, ＋, -, －, !, **not** <sup>_(2)_</sup>  
_binary-operator_ = _assign-op_ | _logical-op_ | _relational-op_ | _arithmetic-op_ <sup>_(2)_</sup>  
  
_assign-op_ = _one of_ \<-, :=, ←, &=, |=, \^=, +=, -=, \*=, /=, %=  
_logical-op_ = _one of_ &, &&, |, ||, ^, **and**, **or**, **xor**  
_relational-op_ = _one of_ =, ==, !=, <>, #, ≠, <, \<=, ≤, ≯, >=, ≥, ≮, >  
_arithmetic-op_ = _one of_ +, ＋, -, －, *, ×, ✕, /, ÷, ／, %  
  
_bool_ = _one of_ **true**, **false**  
_char_ = any single character enclosed in single quotes: 'A'  
_string_ = any character sequence enclosed in double quotes: "Hello, World!"  
  
_timespan_ = @"\^\\[(?:(\d+)\\.)?(\d\d?)\\:(\d\d?)(?:\\:(\d\d?)(\\.\d+)?)?\\]"  
_datetime_ = @"\^\\[(\d{4})-(\d\d?)\-(\d\d?)(?: (\d\d?)\\:(\d\d?)(?:\\:(\d\d?)(\\.\d+)?)?)?\\]"  
  
_separator_ = comma | semicolon  

comma = ','
dot = '.'
lbrace = '{'
lparen = '('
rbrace = '}'
rparen = ')'  
semicolon = ';'
  
Notes:  
1. Case-insensitive.  
2. Case-insensitive and reserved.  
3. Numeric _constants_ are parsed according to the following rules:  
   - Any preceding '+' or '-' signs are treated as _unary-operators_, not part of the _constant_ value.  
   - A sequence of numeric digits '\d+' indicates an _int_.  
   - Append 'U' for _uint_, 'L' for _long_, 'UL' or 'LU' for _ulong_.  
   - Or include a decimal point '.' and/or append an exponent part 'E[-+]\d+' to obtain a _double_.  
   - A final suffix 'D' is optional for _double_; use 'F' or 'M' instead for _float_ or _decimal_.  
  
## _ʞɯɾ_ Further Notes  
  
- ***Comments***, /* using C notation, */ are treated as // whitespace.  
- The concatenation of any two _ʞɯɾ_ _programs_ is a _ʞɯɾ_ _program_.  
- Since any _ʞɯɾ_ _program_ is syntactically just just a _block_, it can be enclosed in parentheses and used as the argument list to a _function_ in another _program_.  
- **All *functions*** are implemented as extensions, and may be invoked using either member or static syntax, with or without the dot "operator" (which is therefore optional, and treated as whitespace whenever present).  
- **A *function*'s parentheses** are optional if the number of _terms_ to be enclosed is 0 or 1; otherwise, a semicolon-separated list in parentheses is needed. Note that the definition of a single _term_ allows for the daisy-chaining of any number of follow-on _functions_, and that any initial _cast(s)_ or _unary-operators_ apply to the result of the entire chain.
  
To illustrate a few aspects of the previous two points, we note that the following filter conditions are all equivalent:  
  
    Title.Contains("Love"); // Canonical member function syntax.
    title contains "Love";  // Case insensitive keywords. Optional dot operator & parentheses removed.
    contains(title, "Love") // Freely change function styles between "member" and "static".
  
- **RegeX**: many _functions_ have vanilla and regular expression (Regex) versions. The Regex variants have an **X** appended to the _function-name_ of the vanilla version. Examples are **StartsWithX**, **ContainsX**, **EndsWithX**, **EqualsX**, **IndexOfX**, **LastIndexOfX**, **CountX**, and **ReplaceX**, all of which accept a Regex pattern in place of a plain string argument.  
- ***Field* names** need not follow the usual naming conventions, but can instead start with a digit or symbol, and contain further symbols and/or embedded spaces; e.g. **\#&nbsp;Album&nbsp;Artists**, **1st&nbsp;Album&nbsp;Artist**, **Year/Album**. But with great power comes great heatsinks! You should probably avoid renaming a _field_ to something like **123** or **3D** or **3M**, which could be mistaken for an actual (e.g. _int_, _double_, _decimal_) _constant_.  
- ***Operator* symbols** include several aliases for certain operations, e.g. assignment can be represented by any of the symbols \<-, :=, ← interchangeably.  
- **The name of _ʞɯɾ_ language** is just the author's initials, upside down.  
  
## _ʞɯɾ_ Case Notes  
  
_ʞɯɾ_ code can respect or ignore character case. ***This affects <u>only</u> user data comparison functions***; _ʞɯɾ_'s _function_, _operator_ and _field_ names always ignore case.  But _functions_ like **Contains** or **ContainsX**, accepting a user-provided string, use this setting.  
  
All affected _functions_ have an optional final argument, _bool caseSensitive_, controlling their case sensitivity. If no value is supplied, this argument is autofilled with the current global setting.  
  
Where does this setting come from? The nearest _Case Sensitive_ checkbox:  
  
- Filters, applied by typing a condition into the general filter area of the app, or by launching the Filter Editor, will respect the _Case Sensitive_ checkbox nearby.  
- Find & Replace operations will respect the _Case Sensitive_ checkbox in their own Find & Replace area of the UI.  
  
To change this global setting during execution, assign **true** or **false** to CaseSensitive:  
  
    CaseSensitive := true;                     // Set an initial global value.
    Sense := Title.Contains("love");           // Performs a case-sensitive comparison.
    Nonsense := Title.Contains("love", false); // Overrides global setting, ignores case.
    CaseSensitive := false;                    // Change the global setting.
    Nonsense := Title.Contains("love");        // Now performs a case-insensitive comparison.
    Sense := Title.Contains("love", true);     // Overrides global setting, respects case.

## _ʞɯɾ_ Variables  
  
A _variable_ is created when its name first appears. Here are several new _variables_ being initialized with _constant_ values of various types:  
  
    bool1 := true;                  // bool  
    char1 := 'A';                   // char  
    greeting := "Hello World!";     // string  
    Int1 := 123456789;              // int  
    Unsigned1 := 123456789U;        // uint  
    Long1 := 9876543210L;           // long  
    UnsignedLong1 := 9876543210UL;  // ulong  
    Double1 := 123.45;              // double  
    Double2 := 123.45D;             // double  
    Double3 := 123.45E-6;           // double = 0.00012345  
    Float1 := 123.45F;              // float  
    Float2 := 123.45E-3F;           // float = 0.12345  
    Money1 := 123.45M;              // decimal  
    Today := [2024-5-14];           // date           [yyyy-M-d]  
    RightNow := [2024-5-14 15:12];  // date & time    [yyyy-M-d H:m]  
    sec := [2024-5-14 15:12:25];    // including sec  [yyyy-M-d H:m:s]  
    ms := [2024-5-14 15:12:25.625]; // including msec [yyyy-M-d H:m:s.fff]  
    TimeOfDay := [14:25];           // no time zone   [H:m]  
    SongLength := [0:3:25];         // including sec  [H:m:s]  
    PersonalBest := [1:25:59.987];  // including msec [H:m:s.fff]  

At the time of writing, _array-variables_ are work in progress...
