let pass = "12345678"; // change to the given encrypted password
let decryptedPass = "";
    for(let i = 0; i <= pass.length - 1; i++){
       decryptedPass += String.fromCharCode(pass[i].charCodeAt(0) - i);
       console.log(decryptedPass);
    }
