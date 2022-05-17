import React from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Register = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [isPending, setIsPending] = useState(false);
    const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();
    const blog = { username, password };

    setIsPending(true);

    fetch('https://localhost:5001/User', {
          method: 'POST',
          headers: { "Content-Type": "application/json"},
          body: JSON.stringify(blog)
      }).then(() => {
          console.log("New User Added");
          setIsPending(false);
          navigate('/login');
      });
  }

  return (
    <div id='register'>
        <h2>Register new user:</h2>
        <form onSubmit={handleSubmit}>
            <div className="input-container">
                <label>Username: </label>
                <input 
                    type="text" 
                    value={username} 
                    onChange={(e) => setUsername(e.target.value)} 
                    required 
                />
            </div>
            <div className="input-container">
                <label>Password: </label>
                <input 
                    type="text" 
                    value={password} 
                    onChange={(e) => setPassword(e.target.value)} 
                    required 
                />
            </div>
            <div className="button-container">
                { !isPending && <button>Submit</button>}
                { isPending && <button disabled>Submitting ..... </button>}
            </div>
        </form>
    </div>
  )
}

export default Register;