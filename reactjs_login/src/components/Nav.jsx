import './nav.scss';

function Nav() {
  return (
    <div className='nav'>
      <div className='links' >
        <a href='/home'>Home</a>
        <a href='/login'>Login</a>
        <a href='/register'>Register</a>
      </div>
    </div>
  )
}

export default Nav