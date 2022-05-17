import React from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Login = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [isPending, setIsPending] = useState(false);
    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
    
        setIsPending(true);
    
        fetch(`https://localhost:5001/User/${username}/uname/${password}/pwd`, {
              method: 'GET',
              headers: { "Content-Type": "application/json"}
          }).then((response) => {
              if(response.ok){
                console.log("Login Success!");
                console.log(username);
                console.log(password);
                navigate('/users');
              }
              else {
                throw new Error('Wrong Login Details ...');
              }
              setIsPending(false);
          });
      }
  return (
    <div id='login'>
        <h2>Login:</h2>
        <form onSubmit={handleSubmit}>
            <div className="input-container">
                <label>Username: </label>
                <input 
                    type="text" 
                    required 
                    value={username} 
                    onChange={(e) => setUsername(e.target.value)}
                />
            </div>
            <div className="input-container">
                <label>Password: </label>
                <input 
                    type="text" 
                    required
                    onChange={(e) => setPassword(e.target.value)} 
                    value={password} 
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

export default Login;