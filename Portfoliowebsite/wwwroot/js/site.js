function naiveEmailCheck(email) {
    return /@/.test(email);
}

function setupValidation() {
    const form = document.getElementById('contactForm');
    const hp = document.getElementById('website');
    const email = document.getElementById('Email');
    const name = document.getElementById('Name');
    const msg = document.getElementById('Message');

    const echo = (id, value) => {
        document.getElementById(id).innerHTML = `\n <span>Probleem met: ${value}</span>\n `;
    };

    const reset = (id) => {
        document.getElementById(id).innerHTML = ` `;
    }

    [email, name, msg].forEach(el => {
        el.addEventListener('input', () => {

            if (el === email) {
                reset("emailErr")
                if (!naiveEmailCheck(el.value)) {
                    echo('emailErr', el.value);
                }
            } else if (el === name) {
                reset("nameErr")
                if (el.value.length < 2) {
                    echo('nameErr', el.value);
                }
            } else if (el === msg) {
                reset("msgErr")
                if (el.value.length < 5) {
                    echo('msgErr', el.value);
                }
            }
        });
    });

    form.addEventListener('submit', (e) => {
        if (hp.value) {
            e.preventDefault();
            alert('Spam gedetecteerd (client-side)!');
            return false;
        }

        return true;
    });
}

window.addEventListener('DOMContentLoaded', setupValidation);