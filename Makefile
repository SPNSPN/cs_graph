CSC := '/mnt/c/Windows/Microsoft.NET/Framework64/v4.0.30319/csc.exe'
LIB := 'C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319,C:\\Windows\Microsoft.NET\\assembly\\GAC_MSIL'

Main.exe: Main.cs GraphForm.cs
	$(CSC) /lib:$(LIB) /reference:C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\System.Windows.Forms.DataVisualization.dll Main.cs GraphForm.cs

.PHONY: clean
clean:
	rm Main.exe
