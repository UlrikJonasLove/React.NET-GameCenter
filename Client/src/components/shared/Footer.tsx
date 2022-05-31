import { title, activeYear } from "../../constants/GameCenterVariables"

export const Footer = () => {
    return(
        <footer className="bd-footer py-5 mt-5 bg-light fixed-bottom">
              <div className='container'>
                {title} &copy; {activeYear} {/* Footer with current year */}
              </div>
        </footer>  
    )
}