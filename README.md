# The _ʞɯɾ_ language

The TagScanner7 app uses the _ʞɯɾ_ scripting language (pronounced _coor_) to help interrogate and maintain ID3V2 metadata tags on audiovisual media files. So what is _ʞɯɾ_?

    Artist = "The Beatles"
    and (Album.StartsWith("Sgt. Pepper's") or Album.Contains("Beatles"))
    and Title.Contains("Love")
    and Decade = "1960s"

Simple filters like this can be written in _ʞɯɾ_, using a combination of tag _field_ names (**Artist**, **Album**, **Title**, etc.), _constant_ values ("The Beatles", "Sgt. Pepper's"), _functions_ (**Contains**, **StartsWith**) and connecting _operator_ symbols like =, **and**, **or**.  

To get an idea of the scope and power of the language, it helps to get an overview of its structure. The first step is examining its _syntax_.

- A _ʞɯɾ_ _program_ is a single _block_ (a sequence of comma separated _compounds_).  
- A _compound_ is a sequence of _binary-operator_ separated _terms_.  
- A _term_ is... actually, let's have the grammar speak for itself:  

## _ʞɯɾ_ syntax

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

_assign-op_ = _one of_ <-, :=, ←, &=, |=, \^=, +=, -=, \*=, /=, %=  
_logical-op_ = _one of_ &, &&, |, ||, ^, **and**, **or**, **xor**  
_relational-op_ = _one of_ =, ==, !=, <>, #, ≠, <, \<=, ≤, ≯, >=, ≥, ≮, >  
_arithmetic-op_ = _one of_ +, ＋, -, －, *, ×, ✕, /, ÷, ／, %  

comma = ','&nbsp;&nbsp;&nbsp; dot = '.'&nbsp;&nbsp;&nbsp; lbrace = '{'&nbsp;&nbsp;&nbsp; rbrace = '}'&nbsp;&nbsp;&nbsp; lparen = '('&nbsp;&nbsp;&nbsp; rparen = ')'  

Notes:  
1. Case-insensitive.  
2. Case-insensitive and reserved.  
3. Not an exhaustive list; see source code for full details.  
4. _constants_ are parsed by Regex, using specific delimeters, internal format, and/or suffix characters; see source code for full details.  
5. _fields_ need not follow the usual naming conventions, but can instead start with a digit or symbol, and contain further symbols and/or embedded spaces; e.g. **\#&nbsp;Album&nbsp;Artists**, **1st&nbsp;Album&nbsp;Artist**, **Year/Album**. But with great power comes great heatsinks! You should probably avoid renaming a _field_ to something like **123** or **3D** or **3M**, which could be mistaken for an actual (e.g. _int_, _double_, _decimal_) _constant_.  
6. All _functions_ are implemented as extensions, and may be invoked using either member or static syntax, with or without the dot "operator" (which is therefore optional).  
7. _function_ argument parentheses are optional when the number of _terms_ to be enclosed is < 2.  
