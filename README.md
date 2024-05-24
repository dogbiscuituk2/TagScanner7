# _ʞɯɾ_ (pronounced _your_) Language  
  
The TagScanner7 app uses _ʞɯɾ_ language to interrogate and maintain ID3v2 metadata tags on audiovisual media files. So what is _ʞɯɾ_ language? Here's an example:  
  
    Artist = "The Beatles"  
    and (Album.StartsWith("Sgt. Pepper's") or Album.Contains("Beatles"))  
    and Title.Contains("Love")  
    and Decade = "1960s"  
  
Simple _ʞɯɾ_ filters like this are built from predefined tag _field_ names (**Artist**, **Album**, **Title**, etc.), _constant_ values (e.g. character strings "The Beatles", "Sgt. Pepper's"), _functions_ (**Contains**, **StartsWith**), and connecting _operator_ symbols like **+&nbsp;-&nbsp;*&nbsp;/&nbsp;=&nbsp;and&nbsp;or&nbsp;not**.  
  
To see the scope/power of _ʞɯɾ_ language, it helps to get an overview of its structure. Step one: _ʞɯɾ_ _syntax_.  
  
- _ʞɯɾ-program_ is a single _block_ (sequence of _compounds_, separated by semicolons);  
- a _compound_ is a sequence of _terms_, separated by _binary-ops_;  
- a _term_ is... actually, let's have the grammar speak for itself:  
  
## _ʞɯɾ_ Language Syntax <sup><i>(1)</i></sup>  
  
_ʞɯɾ-program_ **\:\:=** _block_  
_block_ **\:\:=** _\{ \{ label ... \} statement \{_ **\;** _\{ label ... \} statement ... \} \}_  
_statement_ **\:\:=** _\{ label_ **\:** _\} compound | if-statement | do-loop |_ **break** _|_ **continue** _|_ **goto** _label _|_ **stop**&nbsp;<sup>(2)</sup>  
_compound_ **\:\:=** _term \{ binary-op term ... \}_  
_term_ **\:\:=** _\{ unary-op | cast ... \} value |_ **(** _block_ **)** _\{ \{_ **.** _\} function ... \}_  
_value_ **\:\:=** _constant | field | function | variable_  
_label_ **\:\:=** **\@\"\[\w\_]+\\:"**  
  
_if-statement_ **\:\:=** **if** _block_ **then** _block \{_ **else** _block \}_ **end**  
_switch-statement_ **\:\:=** **switch** _block \{ \{_ **case** _term_ **:** _... \} block ... \} \{_ **default** **:** _block \}_ **end**  
_do-loop_ **\:\:=** _\{_ **while** _block \}_ **do** _block \{_ **until** _block \}_ **end**  
_try-block_ **\:\:=** **try** _block \{_ **catch** _catch-block ... \} \{_ **finally** _block \}_ **end**  
_catch-block_ **\:\:=** **(** _exception-type variable_ **)** _block_
  
_cast_ **\:\:=** **(** _type_ **)**  
_constant_ **\:\:=** _bool | char | datetime | decimal | double | float | int | long | string | timespan | uint | ulong_&nbsp;<sup>(3,5)</sup>  
_function_ **\:\:=** _function-name \{ term |_ **\(** _\{ block \}_ **\)** _\}_  
_variable_ **\:\:=** _(any unreserved word)_&nbsp;<sup>(3)</sup>  
  
_binary-op_ **\:\:=** _assign-op | logical-op | relational-op | arithmetic-op_&nbsp;<sup>(4)</sup>  
_arithmetic-op_ **\:\:=** _one of_ &nbsp; **+&nbsp;&nbsp; ＋&nbsp;&nbsp; -&nbsp;&nbsp; －&nbsp;&nbsp; \*&nbsp;&nbsp; ×&nbsp;&nbsp; ✕&nbsp;&nbsp; /&nbsp;&nbsp; ÷&nbsp;&nbsp; ／&nbsp;&nbsp; %**  
_assign-op_ **\:\:=** _one of_ &nbsp; **\<-&nbsp;&nbsp; :=&nbsp;&nbsp; ←&nbsp;&nbsp; &=&nbsp;&nbsp; |=&nbsp;&nbsp; \^=&nbsp;&nbsp; +=&nbsp;&nbsp; -=&nbsp;&nbsp; \*=&nbsp;&nbsp; /=&nbsp;&nbsp; %=**  
_logical-op_ **\:\:=** _one of_ &nbsp; **& &nbsp;&nbsp; &&&nbsp;&nbsp; |&nbsp;&nbsp; ||&nbsp;&nbsp; ^&nbsp;&nbsp; and&nbsp;&nbsp; or&nbsp;&nbsp; xor**  
_relational-op_ **\:\:=** _one of_ &nbsp; **=&nbsp;&nbsp; ==&nbsp;&nbsp; !=&nbsp;&nbsp; <>&nbsp;&nbsp; #&nbsp;&nbsp; ≠&nbsp;&nbsp; <&nbsp;&nbsp; \<=&nbsp;&nbsp; ≤&nbsp;&nbsp; ≯&nbsp;&nbsp; >=&nbsp;&nbsp; ≥&nbsp;&nbsp; ≮&nbsp;&nbsp; >**  
_unary-op_ **\:\:=** _one of_ &nbsp; **+&nbsp;&nbsp; ＋&nbsp;&nbsp; -&nbsp;&nbsp; －&nbsp;&nbsp; !&nbsp;&nbsp; not**&nbsp;<sup>(4)</sup>  
  
_bool_ **\:\:=** _one of_ &nbsp; **true&nbsp;&nbsp; false**  
_char_ **\:\:=** _any one character enclosed in single quotes:_ **'A'**  
_string_ **\:\:=** _any character sequence enclosed in double quotes:_ **"Hello, World!"**  
_timespan_ **\:\:=** **@"\^\\[(?:(\d+)\\.)?(\d\d?)\\:(\d\d?)(?:\\:(\d\d?)(\\.\d+)?)?\\]"**  
_datetime_ **\:\:=** **@"\^\\[(\d{4})-(\d\d?)\-(\d\d?)(?: (\d\d?)\\:(\d\d?)(?:\\:(\d\d?)(\\.\d+)?)?)?\\]"**  

<details><summary><i>field</i> <b>::=</b> <i>one of</i> <b>Album</b><i>,</i> <b>Album&nbsp;Artist</b><i>,</i> ... <i>(click here for the full list of field names and their types)</i>&nbsp;<sup>(3)</sup></summary>  
<blockquote>
<br>
<b>Album</b> <i>(string)</i><br>
<b>Album Artist</b> <i>(string)</i><br>
<b>Album Artists</b> <i>(string[])</i><br>
<b># Album Artists</b> <i>(int)</i><br>
<b>Album Artists (sorted)</b> <i>(string[])</i><br>
<b># Album Artists (sorted)</b> <i>(int)</i><br>
<b>Album Gain</b> <i>(string)</i><br>
<b>Album Peak</b> <i>(string)</i><br>
<b>Album (sort by)</b> <i>(string)</i><br>
<b>Amazon ID</b> <i>(string)</i><br>
<b>Artist</b> <i>(string)</i><br>
<b>Artists</b> <i>(string[])</i><br>
<b># Artists</b> <i>(int)</i><br>
<b>Artists (joined)</b> <i>(string)</i><br>
<b>Audio Bit Rate</b> <i>(int)</i><br>
<b># Audio Channels</b> <i>(int)</i><br>
<b>Audio Sample Rate</b> <i>(int)</i><br>
<b>BPM</b> <i>(int)</i><br>
<b># Bits Per Sample</b> <i>(int)</i><br>
<b>Century</b> <i>(string)</i><br>
<b>Classical?</b> <i>(Logical)</i><br>
<b>Codecs</b> <i>(string)</i><br>
<b>Comments</b> <i>(string)</i><br>
<b>Composer</b> <i>(string)</i><br>
<b>Composers</b> <i>(string[])</i><br>
<b># Composers</b> <i>(int)</i><br>
<b>Composers (sorted)</b> <i>(string[])</i><br>
<b># Composers (sorted)</b> <i>(int)</i><br>
<b>Conductor</b> <i>(string)</i><br>
<b>Copyright</b> <i>(string)</i><br>
<b>Decade</b> <i>(string)</i><br>
<b>Disc #</b> <i>(int)</i><br>
<b>Disc # of #</b> <i>(string)</i><br>
<b>Disc & Track #</b> <i>(string)</i><br>
<b># Discs</b> <i>(int)</i><br>
<b>Duration</b> <i>(TimeSpan)</i><br>
<b>Empty?</b> <i>(Logical)</i><br>
<b>File Attributes</b> <i>(string)</i><br>
<b>File Created</b> <i>(DateTime)</i><br>
<b>File Created (UTC)</b> <i>(DateTime)</i><br>
<b>File Extension</b> <i>(string)</i><br>
<b>File Accessed</b> <i>(DateTime)</i><br>
<b>File Accessed (UTC)</b> <i>(DateTime)</i><br>
<b>File Modified</b> <i>(DateTime)</i><br>
<b>File Modified (UTC)</b> <i>(DateTime)</i><br>
<b>File Name</b> <i>(string)</i><br>
<b>File Name (no ext)</b> <i>(string)</i><br>
<b>File Path</b> <i>(string)</i><br>
<b>File Size</b> <i>(long)</i><br>
<b>File Status</b> <i>(FileStatus)</i><br>
<b>First Album Artist</b> <i>(string)</i><br>
<b>First Album Artist (sorted)</b> <i>(string)</i><br>
<b>First Artist</b> <i>(string)</i><br>
<b>First Composer</b> <i>(string)</i><br>
<b>First Composer (sorted)</b> <i>(string)</i><br>
<b>First Genre</b> <i>(string)</i><br>
<b>First Performer</b> <i>(string)</i><br>
<b>First Performer (sorted)</b> <i>(string)</i><br>
<b>Genre</b> <i>(string)</i><br>
<b>Genres</b> <i>(string[])</i><br>
<b># Genres</b> <i>(int)</i><br>
<b>Grouping</b> <i>(string)</i><br>
<b>Image Altitude</b> <i>(double)</i><br>
<b>Image Creator</b> <i>(string)</i><br>
<b>Image Date/Time</b> <i>(DateTime)</i><br>
<b>Image Exposure Time</b> <i>(double)</i><br>
<b>Image 'F' Number</b> <i>(double)</i><br>
<b>Image Focal Length</b> <i>(double)</i><br>
<b>Image Focal Length (35mm)</b> <i>(int)</i><br>
<b>Image ISO Speed</b> <i>(int)</i><br>
<b>Image Keywords</b> <i>(string[])</i><br>
<b>Image Latitude</b> <i>(double)</i><br>
<b>Image Longitude</b> <i>(double)</i><br>
<b>Image Make</b> <i>(string)</i><br>
<b>Image Model</b> <i>(string)</i><br>
<b>Image Orientation</b> <i>(ImageOrientation)</i><br>
<b>Image Rating</b> <i>(int)</i><br>
<b>Image Software</b> <i>(string)</i><br>
<b>Invariant End Position</b> <i>(long)</i><br>
<b>Invariant Start Position</b> <i>(long)</i><br>
<b>Lyrics</b> <i>(string)</i><br>
<b>Media Description</b> <i>(string)</i><br>
<b>Media Types</b> <i>(MediaTypes)</i><br>
<b>Millennium</b> <i>(string)</i><br>
<b>Mime Type</b> <i>(string)</i><br>
<b>MusicBrainz Artist ID</b> <i>(string)</i><br>
<b>MusicBrainz Disc ID</b> <i>(string)</i><br>
<b>MusicBrainz Release Artist ID</b> <i>(string)</i><br>
<b>MusicBrainz Release Country</b> <i>(string)</i><br>
<b>MusicBrainz Release ID</b> <i>(string)</i><br>
<b>MusicBrainz Release Status</b> <i>(string)</i><br>
<b>MusicBrainz Release Type</b> <i>(string)</i><br>
<b>MusicBrainz Track ID</b> <i>(string)</i><br>
<b>MusicIP PUID</b> <i>(string)</i><br>
<b>Performers</b> <i>(string[])</i><br>
<b># Performers</b> <i>(int)</i><br>
<b>Performers (joined, sorted)</b> <i>(string)</i><br>
<b>Performers (sorted)</b> <i>(string[])</i><br>
<b># Performers (sorted)</b> <i>(int)</i><br>
<b>Photo Height</b> <i>(int)</i><br>
<b>Photo Quality</b> <i>(int)</i><br>
<b>Photo Width</b> <i>(int)</i><br>
<b>Pictures</b> <i>(string)</i><br>
<b># Pictures</b> <i>(Picture[])</i><br>
<b>Possibly Corrupt?</b> <i>(Logical)</i><br>
<b>Tag Types</b> <i>(TagTypes)</i><br>
<b>Tag Types on Disk</b> <i>(TagTypes)</i><br>
<b>Title</b> <i>(string)</i><br>
<b>Title (sort by)</b> <i>(string)</i><br>
<b># Tracks</b> <i>(int)</i><br>
<b>Track Gain</b> <i>(string)</i><br>
<b>Track #</b> <i>(int)</i><br>
<b>Track # of #</b> <i>(string)</i><br>
<b>Track Peak</b> <i>(string)</i><br>
<b>Video Height</b> <i>(int)</i><br>
<b>Video Width</b> <i>(int)</i><br>
<b>Year</b> <i>(int)</i><br>
<b>Year/Album</b> <i>(string)</i><br>
</blockquote>
</details>  

<details><summary><i>function-name</i> <b>::=</b> <i>one of</i> <b>Compare</b><i>,</i> <b>Concat</b><i>,</i> ... <i>(click here for the full list of functions and their signatures)</i>&nbsp;<sup>(4)</sup></summary>  
<blockquote>
<br><b><i>String Functions</i></b><br><br>
<i>int</i> <b>Compare</b><i>(this string strA, string strB, bool caseSensitive)</i><br>
<i>string</i> <b>Concat</b><i>(params object[] values)</i><br>
<i>string</i> <b>Concat_2</b><i>(this string s, string t)</i><br>
<i>string</i> <b>Concat_3</b><i>(this string s, string t, string u)</i><br>
<i>string</i> <b>Concat_4</b><i>(this string s, string t, string u, string v)</i><br>
<i>bool</i> <b>Contains</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>bool</i> <b>ContainsX</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>int</i> <b>Count</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>int</i> <b>CountX</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>bool</i> <b>Empty</b><i>(this string input)</i><br>
<i>bool</i> <b>EndsWith</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>bool</i> <b>EndsWithX</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>bool</i> <b>Equals</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>bool</i> <b>EqualsX</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>string</i> <b>Format</b><i>(this string format, params object[] args)</i><br>
<i>int</i> <b>IndexOf</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>int</i> <b>IndexOfX</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>string</i> <b>Insert</b><i>(this string input, int startIndex, string value)</i><br>
<i>string</i> <b>Join</b><i>(this string separator, params object[] values)</i><br>
<i>int</i> <b>LastIndexOf</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>int</i> <b>LastIndexOfX</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>int</i> <b>Length</b><i>(this string input)</i><br>
<i>string</i> <b>Lower</b><i>(this string input)</i><br>
<i>string</i> <b>Remove</b><i>(this string input, int startIndex, int count)</i><br>
<i>string</i> <b>Replace</b><i>(this string input, string pattern, string replacement, bool caseSensitive)</i><br>
<i>string</i> <b>ReplaceX</b><i>(this string input, string pattern, string replacement, bool caseSensitive)</i><br>
<i>bool</i> <b>StartsWith</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>bool</i> <b>StartsWithX</b><i>(this string input, string pattern, bool caseSensitive)</i><br>
<i>string</i> <b>Substring</b><i>(this string input, int startIndex, int length)</i><br>
<i>string</i> <b>ToString</b><i>(this object input)</i><br>
<i>string</i> <b>Trim</b><i>(this string input)</i><br>
<i>string</i> <b>Upper</b><i>(this string input)</i><br>
<br><b><i>Math Functions</i></b><br><br>
<i>double</i> <b>Max</b><i>(this double x, double y)</i><br>
<i>double</i> <b>Min</b><i>(this double x, double y)</i><br>
<i>double</i> <b>Pow</b><i>(this double x, double y)</i><br>
<i>double</i> <b>Round</b><i>(this double value)</i><br>
<i>int</i> <b>Sign</b><i>(this double value)</i><br>
<i>double</i> <b>Truncate</b><i>(this double value)</i><br>
<br><b><i>I/O Functions</i></b><br><br>
<i>string</i> <b>Input</b><i>(this string prompt)</i><br>
<i>void</i> <b>Print</b><i>(params object[] values)</i><br>
<i>void</i> <b>PrintLine</b><i>(params object[] values)</i><br>
<br><b><i>Miscellaneous Functions</i></b><br><br>
<i>object</i> <b>IfThenElse</b><i>(bool condition, object consequent, object alternative)</i><br>
</blockquote>
</details>

**Notes:**  
1. <a href="https://en.wikipedia.org/wiki/Extended_Backus%E2%80%93Naur_form"><i><u>EBNF</u></i></a> is for experts, this schema is a little less formal:  
    - nonterminal items appear in _italics_;  
    - terminal items in **bold** represent themselves;  
    - terminal strings prefixed with **@** are <a href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expressions"><i><u>.NET Regex</u></i></a> patterns;  
    - _\{ item \}_ is an optional item (may appear 0 or 1 times);  
    - _\{ item ... \}_ may repeat any number of times (including 0).  

2. The **break** and **continue** statements can only appear in the body (_block_ portion) of a _do-loop_, while the **stop** statement cannot transfer control to the interior of any such nested scope.  
3. Case-insensitive.  
4. Case-insensitive and reserved.  
5. Numeric _constants_ follow these rules:  
   - Any preceding '+' or '-' signs are treated as _unary-ops_, not part of the _constant_ value;  
   - A sequence of numeric digits '\d+' indicates an _int_;  
   - Append 'U' for _uint_, 'L' for _long_, 'UL' or 'LU' for _ulong_;  
   - Or include a decimal point '.' and/or append an exponent part 'E[-+]\d+' to obtain a _double_;  
   - A final suffix 'D' is optional for _double_; use 'F' or 'M' instead for _float_ or _decimal_.  
  
## _ʞɯɾ_ Further Notes  
  
- ***Comments***, /* using C notation, */ are treated as // whitespace.  
- **All *functions*** are implemented as extensions, and may be invoked using either member or static syntax, with or without the dot "operator" (which is therefore optional, and treated as whitespace whenever present).  
- **A *function*'s parentheses** are optional if the number of _terms_ to be enclosed is 0 or 1; otherwise, a semicolon-separated list in parentheses is needed. Note that the definition of a single _term_ allows for the daisy-chaining of any number of follow-on _functions_, and that any initial _cast(s)_ or _unary-ops_ apply to the result of the entire chain.
  
So for example, the following filter conditions are all equivalent:  
  
    Title.Contains("Love");  // Canonical member function syntax.
    title contains "Love";   // Keywords ignore case. Optional dot & parens removed.
    contains(title, "Love"); // Freely change function styles between "member" and "static".
  
- **RegeX**: many _functions_ have vanilla and regular expression (Regex) versions. The Regex variants have an **X** appended to the _function-name_ of the vanilla version. Examples are **StartsWithX**, **ContainsX**, **EndsWithX**, **EqualsX**, **IndexOfX**, **LastIndexOfX**, **CountX**, and **ReplaceX**, all of which accept a Regex pattern in place of a plain string argument.  
- ***Field* names** may include spaces and other symbols, e.g. **\#&nbsp;Album&nbsp;Artists**, **First&nbsp;Album&nbsp;Artist**, **Track&nbsp;#&nbsp;of&nbsp;#**, **Year/Album**.  
- ***Operator* symbols** include several aliases for certain operations, e.g. assignment can be represented by any of the symbols \<-, :=, ← interchangeably.  
- **The name of _ʞɯɾ_ language** is just the author's initials, upside down.  
  
## _ʞɯɾ_ Case Notes  
  
_ʞɯɾ_ code can respect or ignore character case. ***This affects <u>only</u> user data comparison functions***; _ʞɯɾ_'s _function_, _operator_ and _field_ names always ignore case.  But _functions_ like **Contains** or **ContainsX**, accepting a user-provided string, use this setting.  
  
All affected _functions_ have an optional final argument, _bool caseSensitive_, controlling their case sensitivity. If no value is supplied, this argument is autofilled with the current global setting.  
  
Where does this setting come from? The nearest _Case Sensitive_ checkbox:  
  
- ***Filters***, applied by typing a condition into the general filter area of the app, or by launching the Filter Editor, will respect the _Case Sensitive_ checkbox nearby.  
- ***Find & Replace*** operations will respect the _Case Sensitive_ checkbox in their own UI area.  
  
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
