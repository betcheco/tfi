Option Explicit On
Option Strict On
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class Hasher
    Shared passPhrase As String = "GolfTracking"
    Shared saltValue As String = "mySaltValue"
    Shared hashAlgorithm As String = "SHA1"
    Shared passwordIterations As Integer = 2
    Shared initVector As String = "@1B2c3D4e5F6g7H8"
    Shared keySize As Integer = 256

    Private Shared MD5Hasher As MD5 = MD5.Create()

    Public Shared Function Hash(ByVal pCadena As String) As String

        Using HasheadorMD5 As MD5 = MD5.Create()

            Dim Data As Byte() = HasheadorMD5.ComputeHash(Encoding.UTF8.GetBytes(pCadena))

            Dim SBuilder As New StringBuilder()

            Dim i As Integer
            For i = 0 To Data.Length - 1
                SBuilder.Append(Data(i).ToString("x2"))
            Next i

            Return SBuilder.ToString()

        End Using

    End Function

    Public Shared Function Comparar(pCadena As String, pCadenaHasheada As String) As Boolean

        Return Hash(pCadena) = pCadenaHasheada

    End Function

    Public Shared Function Encriptar(ByVal data As String) As String
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
        Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(data)
        Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
        Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)
        Dim symmetricKey As New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)
        Dim memoryStream As New MemoryStream()
        Dim cryptoStream As New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
        cryptoStream.FlushFinalBlock()
        Dim cipherTextBytes As Byte() = memoryStream.ToArray()
        memoryStream.Close()
        cryptoStream.Close()
        Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)
        Return cipherText
    End Function

    Public Shared Function Desencriptar(ByVal data As String) As String
        Dim cipherTextBytes As Byte() = Nothing

        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

        Try
            cipherTextBytes = Convert.FromBase64String(data)
        Catch ex As Exception
            Throw ex
        End Try
        Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
        Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)
        Dim symmetricKey As New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

        Dim memoryStream As MemoryStream = Nothing
        Try
            memoryStream = New MemoryStream(cipherTextBytes)
        Catch ex As Exception
            Throw ex
        End Try

        Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
        Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}
        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
        memoryStream.Close()
        cryptoStream.Close()
        Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
        Return plainText
    End Function

End Class