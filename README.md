# _ʞɯɾ_ (pronounced _your_) Scripting Language  
  
The TagScanner7 app uses _ʞɯɾ_ scripting language to help interrogate and maintain ID3v2 metadata tags on audiovisual media files. So what is _ʞɯɾ_ language? Here's an example:  
  
    Artist = "The Beatles"  
    and (Album.StartsWith("Sgt. Pepper's") or Album.Contains("Beatles"))  
    and Title.Contains("Love")  
    and Decade = "1960s"  
  
Simple _ʞɯɾ_ filters like this are built from predefined tag _field_ names (**Artist**, **Album**, **Title**, etc.), _constant_ values (e.g. character strings "The Beatles", "Sgt. Pepper's"), _functions_ (**Contains**, **StartsWith**), and connecting _operator_ symbols like +, -, *, /, =, **and**, **or**, **not**.  
  
To see the scope/power of _ʞɯɾ_ language, it helps to get an overview of its structure. Step one: _ʞɯɾ_ _syntax_.  
  
- _ʞɯɾ-program_ is a single _block_ (sequence of _compounds_, separated by semicolons);  
- a _compound_ is a sequence of _terms_, separated by _binary-operators_;  
- a _term_ is... actually, let's have the grammar speak for itself:  
  
## _ʞɯɾ_ Language Syntax  
  
_ʞɯɾ-program = block_  
_block = \{ statement \{_ **\;** _statement ... \} \}__  
_statement = \{ label_ **\:** _\} compound | if-statement | do-loop |_ **break** _|_ **continue** _|_ **goto** _label_ <sup>_(4)_</sup>  
_compound = term \{ binary-operator term ... \}_  
_if-statement =_ **if** _block_ **then** _block \{_ **else** _block \}_ **endif**  
_do-loop = \{_ **while** _block \}_ **do** _block \{_ **until** _block \}_ **loop**  
_term = \{ unary-operator | cast ... \} value |_ **(** _block_ **)** _\{ \{_ **.** _\} function ... \}_  
_value = constant | default | field | function | parameter | variable_  
_label =_ **\@\"\#\w+"**
  
_cast =_ **(** _type_ **)**  
_constant = bool | char | datetime | decimal | double | float | int | long | string | timespan | uint | ulong_ <sup>_(1,3)_</sup>  
_default =_ **\{** _type_ **\}**  
_function = function-name \{ term |_ **\(** _\{ block \}_ **\)** _\}_  
_parameter =_ **Track** <sup>_(2)_</sup>  
_variable = (any unreserved word)_ <sup>_(1)_</sup>  
  
_unary-operator = one of_ **+**_,_ **＋**_,_ **-**_,_ **－**_,_ **!**_,_ **not** <sup>_(2)_</sup>  
_binary-operator = assign-op | logical-op | relational-op | arithmetic-op_ <sup>_(2)_</sup>  
_arithmetic-op = one of_ **+**_,_ **＋**_,_ **-**_,_ **－**_,_ **\***_,_ **×**_,_ **✕**_,_ **/**_,_ **÷**_,_ **／**_,_ **%**  
_assign-op = one of_ **\<-**_,_ **:=**_,_ **←**_,_ **&=**_,_ **|=**_,_ **\^=**_,_ **+=**_,_ **-=**_,_ **\*=**_,_ **/=**_,_ **%=**  
_logical-op = _one of_ **&**_,_ **&&**_,_ **|**_,_ **||**_,_ **^**_,_ **and**_,_ **or**_,_ **xor**  
_relational-op = one of_ **=**_,_ **==**_,_ **!=**_,_ **<>**_,_ **#**_,_ **≠**_,_ **<**_,_ **\<=**_,_ **≤**_,_ **≯**_,_ **>=**_,_ **≥**_,_ **≮**_,_ **>**  
  
_bool = _one of **true**_,_ **false**  
_char = any one character enclosed in single quotes:_ **'A'**  
_string = any character sequence enclosed in double quotes:_ **"Hello, World!"**  
_timespan =_ **@"\^\\[(?:(\d+)\\.)?(\d\d?)\\:(\d\d?)(?:\\:(\d\d?)(\\.\d+)?)?\\]"**  
_datetime =_ **@"\^\\[(\d{4})-(\d\d?)\-(\d\d?)(?: (\d\d?)\\:(\d\d?)(?:\\:(\d\d?)(\\.\d+)?)?)?\\]"**  

<details><summary><i>field = one of</i> <b>Album</b><i>,</i> <b>Album Artist</b><i>,</i> ... <i>(click here for full list) <sup>(1)</sup>  </i></summary><b>
Album<br>
Album Artist<br>
Album Artists<br>
# Album Artists<br>
Album Artists (sorted)<br>
# Album Artists (sorted)<br>
Album Gain<br>
Album Peak<br>
Album (sort by)<br>
Amazon ID<br>
Artist<br>
Artists<br>
# Artists<br>
Artists (joined)<br>
Audio Bit Rate<br>
# Audio Channels<br>
Audio Sample Rate<br>
BPM<br>
# Bits Per Sample<br>
Century<br>
Classical?<br>
Codecs<br>
Comments<br>
Composer<br>
Composers<br>
# Composers<br>
Composers (sorted)<br>
# Composers (sorted)<br>
Conductor<br>
Copyright<br>
Decade<br>
Disc #<br>
Disc # of #<br>
Disc & Track #<br>
# Discs<br>
Duration<br>
Empty?<br>
File Attributes<br>
File Created<br>
File Created (UTC)<br>
File Extension<br>
File Accessed<br>
File Accessed (UTC)<br>
File Modified<br>
File Modified (UTC)<br>
File Name<br>
File Name (no ext)<br>
File Path<br>
File Size<br>
File Status<br>
First Album Artist<br>
First Album Artist (sorted)<br>
First Artist<br>
First Composer<br>
First Composer (sorted)<br>
First Genre<br>
First Performer<br>
First Performer (sorted)<br>
Genre<br>
Genres<br>
# Genres<br>
Grouping<br>
Image Altitude<br>
Image Creator<br>
Image Date/Time<br>
Image Exposure Time<br>
Image 'F' Number<br>
Image Focal Length<br>
Image Focal Length (35mm)<br>
Image ISO Speed<br>
Image Keywords<br>
Image Latitude<br>
Image Longitude<br>
Image Make<br>
Image Model<br>
Image Orientation<br>
Image Rating<br>
Image Software<br>
Invariant End Position<br>
Invariant Start Position<br>
Lyrics<br>
Media Description<br>
Media Types<br>
Millennium<br>
Mime Type<br>
MusicBrainz Artist ID<br>
MusicBrainz Disc ID<br>
MusicBrainz Release Artist ID<br>
MusicBrainz Release Country<br>
MusicBrainz Release ID<br>
MusicBrainz Release Status<br>
MusicBrainz Release Type<br>
MusicBrainz Track ID<br>
MusicIP PUID<br>
Performers<br>
# Performers<br>
Performers (joined, sorted)<br>
Performers (sorted)<br>
# Performers (sorted)<br>
Photo Height<br>
Photo Quality<br>
Photo Width<br>
Pictures<br>
# Pictures<br>
Possibly Corrupt?<br>
Tag Types<br>
Tag Types on Disk<br>
Title<br>
Title (sort by)<br>
# Tracks<br>
Track Gain<br>
Track #<br>
Track # of #<br>
Track Peak<br>
Video Height<br>
Video Width<br>
Year<br>
Year/Album<br>
</b></details>  

<details><summary><i>function-name = one of</i> <b>Compare</b><i>,</i> <b>Concat</b><i>,</i> ... <i>(click here for full list) <sup>(2)</sup></i></summary><b>
Compare<br>
Concat<br>
Contains<br>
ContainsX<br>
Count<br>
CountX<br>
Empty<br>
EndsWith<br>
EndsWithX<br>
Equals<br>
EqualsX<br>
Format<br>
IfThenElse<br>
IndexOf<br>
IndexOfX<br>
Input<br>
Insert<br>
Join<br>
LastIndexOf<br>
LastIndexOfX<br>
Length<br>
Lower<br>
Max<br>
Min<br>
Pow<br>
Print<br>
PrintLine<br>
Remove<br>
Replace<br>
ReplaceX<br>
Round<br>
Sign<br>
StartsWith<br>
StartsWithX<br>
Substring<br>
ToString<br>
Trim<br>
Truncate<br>
Upper<br>
</b></details>

Notes:  
1. Case-insensitive.  
2. Case-insensitive and reserved.  
3. Numeric _constants_ are parsed according to the following rules:  
   - Any preceding '+' or '-' signs are treated as _unary-operators_, not part of the _constant_ value.  
   - A sequence of numeric digits '\d+' indicates an _int_.  
   - Append 'U' for _uint_, 'L' for _long_, 'UL' or 'LU' for _ulong_.  
   - Or include a decimal point '.' and/or append an exponent part 'E[-+]\d+' to obtain a _double_.  
   - A final suffix 'D' is optional for _double_; use 'F' or 'M' instead for _float_ or _decimal_.  
4. The **break** and **continue** statements are only available within the body, i.e. the _block_ portion, of a _do-loop_.  
  
## _ʞɯɾ_ Further Notes  
  
- ***Comments***, /* using C notation, */ are treated as // whitespace.  
- Since any _ʞɯɾ_ _program_ is syntactically just just a _block_, it can be enclosed in parentheses and used as the argument list to a _function_ in another _program_.  
- **All *functions*** are implemented as extensions, and may be invoked using either member or static syntax, with or without the dot "operator" (which is therefore optional, and treated as whitespace whenever present).  
- **A *function*'s parentheses** are optional if the number of _terms_ to be enclosed is 0 or 1; otherwise, a semicolon-separated list in parentheses is needed. Note that the definition of a single _term_ allows for the daisy-chaining of any number of follow-on _functions_, and that any initial _cast(s)_ or _unary-operators_ apply to the result of the entire chain.
  
So for example, the following filter conditions are all equivalent:  
  
    Title.Contains("Love");  // Canonical member function syntax.
    title contains "Love";   // Keywords ignore case. Optional dot & parens removed.
    contains(title, "Love"); // Freely change function styles between "member" and "static".
  
- **RegeX**: many _functions_ have vanilla and regular expression (Regex) versions. The Regex variants have an **X** appended to the _function-name_ of the vanilla version. Examples are **StartsWithX**, **ContainsX**, **EndsWithX**, **EqualsX**, **IndexOfX**, **LastIndexOfX**, **CountX**, and **ReplaceX**, all of which accept a Regex pattern in place of a plain string argument.  
- ***Field* names** need not follow the usual naming conventions, but can instead start with a digit or symbol, and contain further symbols and/or embedded spaces; e.g. **\#&nbsp;Album&nbsp;Artists**, **1st&nbsp;Album&nbsp;Artist**, **Year/Album**. But with great power comes great heatsinks! You should probably avoid renaming a _field_ to something like **123** or **3D** or **3M**, which could be mistaken for an actual (e.g. _int_, _double_, _decimal_) _constant_.  
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
