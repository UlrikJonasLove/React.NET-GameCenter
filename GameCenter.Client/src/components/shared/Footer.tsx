import { title } from "../../constants/GameCenterVariables"

export const Footer = () => {
    return(
        <footer className="bd-footer py-5 mt-5 bg-light">
              <div className='container'>
                {title} &copy; {new Date().getFullYear()} {/* Footer with current year */}
              </div>
        </footer>  
    )
}