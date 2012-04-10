
require 'watir-webdriver'
require 'test/unit'
 
class Payment
  attr_accessor :cardType, :cardNumber , :expiration, :nameOnCard, :securityNumber, :city,  :state,  :zipCode 
  def initialize(h)
    h.each {|k,v| send("#{k}=",v)}
  end
end
 
class TC_article_example < Test::Unit::TestCase
 
  @@testDir = 'TestResults/' +DateTime.now.strftime("%Y-%m-%d_%H-%M")
  @@url = "http://localhost:22222"
 
  def setup
                if(!File.directory?(@@testDir))
                                d = Dir.mkdir(@@testDir)   
                end
                puts 'results in  ' + @@testDir
  end
  
  
  def test_payment_form
    b = Watir::Browser.new
                p = fill_out_payment_form(b)
                check_payment_table( b , p ) 
                b.close
  end
  
  
   
  def check_payment_table( b , p )  
    b.goto(@@url+"/Account/LogOn")
    b.text_field(:name, "UserName").set("a")
    b.text_field(:name, "Password").set("xxxxxxxxxxx")
    b.button(:type, "submit").click
    b.goto("http://localhost:22222/Admin/Payments")  
                sleep 1 until b.text.include? "CardType"
                b.driver.save_screenshot( @@testDir + '/check_payment_table.png')
               
                b.div(:id => "grid").tbodys.first.links.first.click
                b.driver.save_screenshot( @@testDir + '/check_payment_details.png')
               
                puts p.cardType
                assert(b.text.include?( p.cardType ) )
  end
 
  def fill_out_payment_form(b)
    b.goto(@@url+"/payment") 
                p = Payment.new(:cardType => "Discover", :cardNumber => "5555555555554444", :expiration => "2/2021",
                                                                                :nameOnCard => "Test Tester",:securityNumber => "2121", :city => "city",
                                                                                :state => "il", :zipCode => "21321" )
                p.cardType = p.cardType + Random.rand(10000).to_s
    b.text_field(:name, "CardType").set(p.cardType)
    b.text_field(:name, "CardNumber").set(p.cardNumber)
    b.text_field(:name, "Expiration").set(p.expiration)
    b.text_field(:name, "NameOnCard").set(p.nameOnCard)
    b.text_field(:name, "SecurityNumber").set(p.securityNumber)
    b.text_field(:name, "City").set(p.city) 
    b.text_field(:name, "State").set(p.state) 
    b.text_field(:name, "ZipCode").set(p.zipCode) 
                b.driver.save_screenshot( @@testDir + '/fill_out_payment_form.png' )
    b.button(:type, "submit").click
    assert(b.text.include?("ThankYou")) 
                return p
  end
 
   
  
end
 
 
=begin
class String
  def underscore
    self.gsub(/::/, '/').
    gsub(/([A-Z]+)([A-Z][a-z])/,'\1_\2').
    gsub(/([a-z\d])([A-Z])/,'\1_\2').
    tr("-", "_").
    downcase
  end
end
=end