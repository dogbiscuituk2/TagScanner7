**Model**

The **Model** class represents the collection of data used by the application.  

**Filter**

The **Filter** class is the receptacle for a collection of **Term** objects, any of which may be selected to apply to the data.

**Term**

The **Term** class is the abstract base of the following hierarchy:

- ***Term** (abstract)*
  - **Constant**
  - **Field**
  - **Parameter**
  - ***Umptad** (abstract)*
    - **Cast**
    - **Function**
    - **Operation**

**Constant**

The **Constant** class represents fixed values in expressions. Supported value types are *bool*, *char*, *string*, various numerical integer (*int*, *uint*, *long*, *ulong*) and floating point (*float*, *double*, *decimal*) formats, together with *TimeSpan* and *DateTime*.

**Field**

The **Field** class represents domain item properties. This system was developed primarily to maintain the ID3 tags of a collection of audiovisual media, chiefly MP3 music files, so examples of fields are *Title*, *Duration*, *Album Title*, etc., or file properties such as *File Attributes*, or *File Created*.

Notice that field denotations are permitted to contain spaces. At runtime, the full list of accessible fields, together with their various metadata, will be assembled from the attributes attached to properties in the *Selection* class. This is so for historical reasons; the first UI developed for the application used the Winforms PropertyGrid control, which binds to these attributes. The next stage of development will include moving these into readily available storage, free of recompilation requirements.

**Parameter**

The **Parameter** class is used internally, to provide the default parameter values needed while building expressions manually.

**Umptad** 

The oddly named **Umptad** class is another abstract base, this time for multiterm collections. The name derives from the classification of operators into monadic, dyadic, triadic, tetradic etc. types, based on their number of operands. With some violence to terminology, we might refer to these as Monads, Dyads, Triads, Tetrads, etc.

An operator accepting an indeterminate number of operands can then be said to accept *umpty* or *umpteen* of them; hence, an *umptadic* operator, or *umptad*.

- ***Umptad*** *(abstract)*
  - **Cast**
  - **Function**
  - **Operation**

**Cast**

Class **Cast** is the first and simplest **Umptad** descendant. Taking a single operand, it recasts its ResultType to be some other, compatible new type. For example, the expression

    # Album Artists.Cast(long)

converts the *# Album Artists* property from a normal integer (System.Int32) to a long one (System.Int64).

**Function**

Class **Function** represents a C# method call, taking one **Term** per required function argument, and returning a new **Term** whose ResultType matches that method's return type.

Syntactically there are two varieties of **Function**, *static* and *member*. An example of a *static* **Function** is *Compare*:

    Compare(1st Album Artist, "N")

This compares the value of an item's *1st Album Artist* property to the fixed value *"M"*, and returns a **Constant Term** representing the usual result of performing a static *Compare* method between two strings - in this case, indicating whether the artist would appear in the first or second half of a dictionary.

By contrast, an example of a *member* **Function** might be

    Album Artists (joined).Contains("Beat")

which, in the case of a Beatles song, would return a **Constant Term** with a *ResultType* of *bool*, and a *Value* of *true*.

The available roster of **Function**s is currently found in the Methods.cs file, though the next stage of development will include moving these into readily available storage, free of recompilation requirements.

**Operation**

