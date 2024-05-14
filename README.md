# _ʞɯɾ_ (pronounced _your_) Scripting Language  

The TagScanner7 app uses _ʞɯɾ_ scripting language to help interrogate and maintain ID3v2 metadata tags on audiovisual media files. So what is _ʞɯɾ_ language? Let's look at an example.  

    Artist = "The Beatles"
    and (Album.StartsWith("Sgt. Pepper's") or Album.Contains("Beatles"))
    and Title.Contains("Love")
    and Decade = "1960s"

Simple filters like this can be written in _ʞɯɾ_ language, using a combination of predefined tag _field_ names (**Artist**, **Album**, **Title**, etc.), _constant_ values (for example the character strings "The Beatles", "Sgt. Pepper's"), _functions_ (**Contains**, **StartsWith**), and connecting _operator_ symbols like +, -, *, /, =, **and**, **or**, **not**.  

To get an idea of the scope and power of _ʞɯɾ_ language, it helps to get an overview of its structure. The first step is examining _ʞɯɾ_ _syntax_.  

- _ʞɯɾ_ _program_ is a single _block_ (a sequence of comma separated _compounds_).  
- A _compound_ is a sequence of _binary-operator_ separated _terms_.  
- A _term_ is... actually, let's have the grammar speak for itself:  

## _ʞɯɾ_ Language Syntax  

_program_ = _block_  
_block_ = _compound_ \{ comma _compound_ ... \}  
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

comma = ','&nbsp;&nbsp;&nbsp; dot = '.'&nbsp;&nbsp;&nbsp; lbrace = '{'&nbsp;&nbsp;&nbsp; rbrace = '}'&nbsp;&nbsp;&nbsp; lparen = '('&nbsp;&nbsp;&nbsp; rparen = ')'  

Notes:  
1. Case-insensitive.  
2. Case-insensitive and reserved.  
3. Not an exhaustive list; see source code for full details.  
4. _constants_ are parsed by Regex, using specific delimeters, internal format, and/or suffix characters; see source code for full details.  

## _ʞɯɾ_ Further Notes  

- ***Comments***, /* using C notation, */ are treated as // whitespace.  
- The concatenation of any two _ʞɯɾ_ _programs_, separated by at least one whitespace character, is another _ʞɯɾ_ _program_.  
- Since any _ʞɯɾ_ _program_ is syntactically just just a _block_, it can be enclosed in parentheses and used as the argument list to a _function_ in another _program_.  
- **All *functions*** are implemented as extensions, and may be invoked using either member or static syntax, with or without the dot "operator" (which is therefore optional, and treated as whitespace whenever present).  
- **A *function*'s parentheses** are optional if the number of _terms_ to be enclosed is 0 or 1; otherwise, a comma separated list in parentheses is needed. Note that the definition of a single _term_ allows for the daisy-chaining of any number of follow-on _functions_, and that any initial _cast(s)_ or _unary-operators_ apply to the result of the entire chain.

To illustrate a few aspects of the previous two points, we note that the following filter conditions are all equivalent:  

    Title.Contains("Love"), // Canonical member function syntax.
    title contains "Love",  // Case insensitive keywords. Optional dot operator & parentheses removed.
    contains(title, "Love") // Freely change function styles between "member" and "static".

- **RegeX**: many _functions_ have vanilla and regular expression (Regex) versions. The Regex variants have an **X** appended to the _function-name_ of the vanilla version. Examples are **StartsWithX**, **ContainsX**, **EndsWithX**, **EqualsX**, **IndexOfX**, **LastIndexOfX**, **CountX**, and **ReplaceX**, all of which accept a Regex pattern in place of a plain string argument.  
- ***Field* names** need not follow the usual naming conventions, but can instead start with a digit or symbol, and contain further symbols and/or embedded spaces; e.g. **\#&nbsp;Album&nbsp;Artists**, **1st&nbsp;Album&nbsp;Artist**, **Year/Album**. But with great power comes great heatsinks! You should probably avoid renaming a _field_ to something like **123** or **3D** or **3M**, which could be mistaken for an actual (e.g. _int_, _double_, _decimal_) _constant_.  
- ***Operator* symbols** include several aliases for certain operations, e.g. assignment can be represented by any of the symbols \<-, :=, ← interchangeably.  
- **The name of _ʞɯɾ_ language** is just the author's initials, upside down.  

## _ʞɯɾ_ Case Notes  

_ʞɯɾ_ code can be parsed in either of two alternative ways, either case-sensitively or case-insensitively. ***This option affects only the operation of user data comparison functions***; the language's own _function-names_, operator and _field_ names, etc., are always processed ignoring case.  But when you invoke a particular _function_ like **Contains** or **ContainsX** which accepts a user-provided string value, its result will depend upon this setting.  

All affected _functions_ have an optional final argument, _bool caseSensitive_, which controls the case sensitivity of _only_ the particular, present _function_ invocation. When no value is supplied by the user, this argument is automatically filled with the current global case sensitivity setting, and the comparison _function_ executed accordingly.  

So, where does this default setting come from? Initially, the nearest _Case Sensitive_ checkbox:  

- Filters, applied by typing a condition into the general filter area of the app, or by launching the Filter Editor, will respect the _Case Sensitive_ checkbox nearby.  
- Find & Replace operations will respect the _Case Sensitive_ checkbox in their own Find & Replace area of the UI.  

In the unlikely event that you need to change this setting dynamically during _program_ execution, just assign **true** or **false** to the CaseSensitive _parameter_:  

    CaseSensitive := true,                     // Set an initial global value.
    Sense := Title.Contains("love"),           // Performs a case-sensitive comparison.
    Nonsense := Title.Contains("love", false), // Overrides global setting, ignores case.
    CaseSensitive := false,                    // Change the global setting.
    Nonsense := Title.Contains("love"),        // Now performs a case-insensitive comparison.
    Sense := Title.Contains("love", true)      // Overrides global setting, respects case.
