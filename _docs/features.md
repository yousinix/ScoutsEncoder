---
layout: docs
title: Features
order: 2
---

# Features

## Ciphers

- Check ciphers list from [here]({{ '/docs/available-ciphers' | relative_url }}).
- [Add](#clean-code) your own cipher.
- Request a cipher via [Email](mailto:{{site.author.email}}?subject={{site.title}} - Cipher Request) or via [GitHub Issues]({{site.github.repository_url}}/issues/new?title=Cipher Request)
- Check [Ciphers Handbook]({{ '/docs/ciphers-handbook' | relative_url }}) to know more about the ciphers used in ScoutsEncoder.

## Keys

- You can use different keys for each cipher to get different encodings.
- You can also view the full cipher's encoding with the key used.

![full-cipher]({{ 'assets/img/features/full-cipher.jpg' | relative_url }})

## Encoding

### Real-time Encoding

Encode your text while typing without the need to press any button. Change anything (cipher, key, chars/words delimiter or shape format) and the changes will be reflected instantly.

![real-time]({{ 'assets/img/features/real-time.gif' | relative_url }})

### Output Styles

Customize your output depending on your preferences. Change the chars/words delimiters and their spacing or the fill and stroke of shapes.

![output-styles]({{ 'assets/img/features/output-styles.gif' | relative_url }})

### Audio Output

Export audio output for your Morse encoding with different speeds (slow - medium - fast).

<div class="col my-3 p-0">
    <audio class="w-100" controls>
        <source src="{{ 'assets/wav/MorseCode.wav' | relative_url }}" type="audio/wav">
    </audio>
</div>

![audio-speeds]({{ 'assets/img/features/audio-speeds.jpg' | relative_url }})

## Design

### Light/Dark Themes

Choose the theme that makes you more comfortable.

![themes]({{ 'assets/img/features/themes.jpg'  | relative_url }})

### Responsive Layout

Choose whatever size you like. You can either use it in full screen or side by side with any other window.

![responsive]({{ 'assets/img/features/responsive.gif' | relative_url }})

### Material Design

Designed with Google's [material design](https://material.io/design/) standards using [Material Design In XAML Toolkit](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit).

## Code

### Clean Code

Readable and easy to maintain OOP code using XAML and C#. Adding Ciphers is so easy, anyone can add them even if he doesn't know how to code! Just add the cipher type you want, from the types below, to ciphers array and the rest is done for you.

Check out the following pre-declared ciphers from that [link](https://github.com/YoussefRaafatNasry/ScoutsEncoder/blob/d19c185cb6046c8969ddf68125a90e116da8f88a/ScoutsEncoder/MainWindow.xaml.cs#L42-L212).

```c#

// 1] Normal Cipher:
new Cipher
{
    DisplayName = "اسم_الشفرة", // Add Cipher Name Here (displayed in Ciphers ComboBox)
    HasKeys = true,              // Enables Keys ComboBox
    KeyWeight = n,               // Offsets Keys with the given value (n) where:  0 < n < 28
    IsAudible = true,            // Enables Audio Button
    HasShapes = true,            // Enables Shape Format Button
    CipherCharacters = {"x", "x", "x", "x", "x", "x", "x",  // Add Cipher body Here.
                        "x", "x", "x", "x", "x", "x", "x",  // Must contain 28 values,
                        "x", "x", "x", "x", "x", "x", "x",  // written in an array form
                        "x", "x", "x", "x", "x", "x", "x"}
},

// 2] Overloaded Cipher:
new Cipher
{
    DisplayName = "اسم_الشفرة", // Add Cipher Name Here (displayed in Ciphers ComboBox)
    HasOverloads = true,         // Don't declare any key-related property or CipherCharacters property
    Overloads = new List<Cipher> // Overloads appear in Keys ComboBox, and are initialized as a list
    {
        new Cipher
        {
            DisplayName = "اسم 1", // First overload name (displayed in Keys ComboBox)
            CipherCharacters = {"x", "x", "x", "x", "x", "x", "x", // Add First overload body Here.
                                "x", "x", "x", "x", "x", "x", "x", // Must contain 28 values,
                                "x", "x", "x", "x", "x", "x", "x", // written in an array form
                                "x", "x", "x", "x", "x", "x", "x"}
        },

        new Cipher
        {
            DisplayName = "اسم 2", // Second overload name (displayed in Keys ComboBox)
            CipherCharacters = {"x", "x", "x", "x", "x", "x", "x", // Add Second overload body Here.
                                "x", "x", "x", "x", "x", "x", "x", // Must contain 28 values,
                                "x", "x", "x", "x", "x", "x", "x", // written in an array form
                                "x", "x", "x", "x", "x", "x", "x"}
        }
    }
},

```

### Open Source

Source code is available on [Github]({{ site.github.repository_url }}). Open for contributions and improvements.

## Feature Request

The feature you are searching for isn't mentioned?<br/>
Request your desired feature now!

<a class="btn btn-primary" href="mailto:{{ site.author.email }}?subject={{ site.title }} | Feature Request">via E-Mail</a>
<a class="btn btn-primary" href="{{ site.github.repository_url }}/issues/new?title=Feature Request">via GitHub</a>
