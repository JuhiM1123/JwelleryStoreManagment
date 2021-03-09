import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';


@Injectable({
  providedIn: 'root'
})
export class AESEncryptionDecryptionService {

  constructor(
  ) { }

  encrypt(plainText: any) {
    try {
      let finalResult = null;
      if (plainText) {
        const key = CryptoJS.enc.Utf8.parse('8080808080808080');
        const iv = CryptoJS.enc.Utf8.parse('8080808080808080');
        const encrypted = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(plainText), key, { keySize: 128 / 8, iv });
        if (encrypted === undefined || encrypted === null) {
          throw new Error('Invalid encryption result');
        } else {
          finalResult = encrypted.toString();
        }
      }
      return { isError: false, result: finalResult };
    } catch (error) {
      alert(error.message);
      console.error(error);
      return { isError: true, result: error };
    }
  }

  decrypt(cipherText: any) {
    try {
      const key = CryptoJS.enc.Utf8.parse('8080808080808080');
      const iv = CryptoJS.enc.Utf8.parse('8080808080808080');
      const plainTextArray = CryptoJS.AES.decrypt(cipherText, key, { keySize: 128 / 8, iv });
      const plainText = CryptoJS.enc.Utf8.stringify(plainTextArray);
      return { isError: false, result: plainText };
    } catch (error) {
      alert(error.message);
      console.error(error);
      return { isError: true, result: error };
    }
  }
}