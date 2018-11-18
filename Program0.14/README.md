# Pravda Program Template
Pravda project template based on Program0._14 implementation
# Installing the template
```bash
dotnet new -i Expload.PravdaProgramTemplate
dotnet new pravdaprogram
```
# Building and running
To build pravda program into a `.pravda` binary file:
```bash
dotnet publish
```
To deploy the program to testnet:
```bash
# First, you have to generate a wallet and put it into wallet.json
# (or move it to the folder if you have one)
pravda gen address -o wallet.json

# Then use http://faucet.dev.expload.com/ui to get some EXP

# After you have funds on your wallet, deploy the program
dotnet publish -c Release
```
# FAQ
I get `NotEnoughMoney` exception. What do I do?
> Make sure you've used faucet to get EXP for account in `wallet.json`.

What do I do next?
> Now you can edit the program in Program0._14.cs and deploy scripts
> in Program0._14.csproj to suit your needs. Make sure to check out Pravda docs!

Can I update deployed program with `dotnet publish -c Release`?
> No, you can only deploy the program to a newly generated wallet.
> Check out Program0._14.csproj if you want to alter publish scenario.