# _ʞɯɾ_ (pronounced _your_) Scripting Language  
  
The TagScanner7 app uses _ʞɯɾ_ scripting language to help interrogate and maintain ID3v2 metadata tags on audiovisual media files. So what is _ʞɯɾ_ language? Let's look at an example.  
  
    Artist = "The Beatles"  
    and (Album.StartsWith("Sgt. Pepper's") or Album.Contains("Beatles"))  
    and Title.Contains("Love")  
    and Decade = "1960s"  
  
Simple _ʞɯɾ_ filters like this are built from predefined tag _field_ names (**Artist**, **Album**, **Title**, etc.), _constant_ values (e.g. character strings "The Beatles", "Sgt. Pepper's"), _functions_ (**Contains**, **StartsWith**), and connecting _operator_ symbols like +, -, *, /, =, **and**, **or**, **not**.  
  
To see the scope/power of _ʞɯɾ_ language, it helps to get an overview of its structure. Step one: _ʞɯɾ_ _syntax_.  
  
- _ʞɯɾ_ _program_ is a single _block_ - a sequence of _compounds_, terminated with semicolons.  
- A _compound_ is a sequence of _terms_, separated by _binary-operators_.  
- A _term_ is... actually, let's have the grammar speak for itself:  
  
## _ʞɯɾ_ Language Syntax  
  
_program_ = _block_  
_block_ = \{ _compound_ semicolon ... \}  
_compound_ = _term_ \{ _binary-operator_ _term_ ... \}  
_term_ = \{ _unary-operator_ | _cast_ ... \} _value_ | lparen _block_ rparen \{ \{ dot \} _function_ ... \}  
_cast_ = lparen _type_ rparen  
_value_ = _constant_ | _default_ | _field_ | _function_ | _parameter_ | _variable_  
  
_constant_ = _bool_ | _char_ | _datetime_ | _decimal_ | _double_ | _float_ | _int_ | _long_ | _string_ | _timespan_ | _uint_ | _ulong_ <sup>_(1,4)_</sup>  
_default_ = lbrace _type_ rbrace  
_field_ = _one of_ **Album**, **Artist**, **Duration**, **Title**, ..., **Year** <sup>_(1,3)_</sup>  
_function_ = _function-name_ \{ _term_ | lparen \{ _block_ \} rparen \}  
_parameter_ = **Track** <sup>_(2)_</sup>  
_variable_ = _(any unreserved word)_ <sup>_(1)_</sup>  
  
_function-name_ = _one of_ **Compare**, **Concat**, ..., **Upper** <sup>_(2,3)_</sup>  
_unary-operator_ = _one of_ +, ＋, -, －, !, **not** <sup>_(2)_</sup>  
_binary-operator_ = _assign-op_ | _logical-op_ | _relational-op_ | _arithmetic-op_ <sup>_(2)_</sup>  
  
_assign-op_ = _one of_ \<-, :=, ←, &=, |=, \^=, +=, -=, \*=, /=, %=  
_logical-op_ = _one of_ &, &&, |, ||, ^, **and**, **or**, **xor**  
_relational-op_ = _one of_ =, ==, !=, <>, #, ≠, <, \<=, ≤, ≯, >=, ≥, ≮, >  
_arithmetic-op_ = _one of_ +, ＋, -, －, *, ×, ✕, /, ÷, ／, %  
  
_bool_ = _one of_ **true**, **false**  
_char_ = any single character enclosed in single quotes: 'A'  
_string_ = any character sequence enclosed in double quotes: "Hello, World!"  
  
_timespan_ = lbracket _timespanpattern_ rbracket  
_datetime_ = lbracket _datetimepattern_ rbracket  
  
_timespanpattern_ = a complex Regex!  
_datetimepattern_ = a more complex Regex!  
  
semicolon = ';'&nbsp;&nbsp;&nbsp; dot = '.'&nbsp;&nbsp;&nbsp; lbrace = '{'&nbsp;&nbsp;&nbsp; rbrace = '}'&nbsp;&nbsp;&nbsp; lbracket = '['&nbsp;&nbsp;&nbsp; rbracket = ']'&nbsp;&nbsp;&nbsp; lparen = '('&nbsp;&nbsp;&nbsp; rparen = ')'  
  
Notes:  
1. Case-insensitive.  
2. Case-insensitive and reserved.  
3. Not an exhaustive list; see source code for full details.  
4. Numeric _constants_ are parsed according to the following rules:  
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
    PersonalBest := [1:25:59];      // including msec [H:m:s.fff]  

At the time of writing, _array-variables_ are work in progress...
