For Pact test on Apple M1 install
arch -x86_64 /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install.sh)"
$ arch -x86_64 /usr/local/Homebrew/bin/brew install dotnet

Then run the test though this version of dotnet
$ arch -x86_64 /usr/local/opt/dotnet/bin/dotnet test

In case of upgrade of dotnet launch
$ arch -x86_64 /usr/local/Homebrew/bin/brew update dotnet

