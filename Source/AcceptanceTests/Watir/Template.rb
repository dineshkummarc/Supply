
 
require 'watir-webdriver'
 
@@page = "PaymentInfo"
@@url = "http://localhost:22224/Home/"
b = Watir::Browser.new
b.goto(@@url + @@page)
def build_input_class( file,  list)
                file.puts "class   "+ @@page
                file.write "\tattr_accessor "
                list.each do |input|
                                file.write  ":" + input.name + ","
                end
                file.puts "\n\tdef initialize(h)\n\t\th.each {|k,v| send(\"\#{k}=\",v)}\n\tend\nend"
end       
 
 
def build_fill_out_form( file,  list)
                page = @@page.downcase
                file.puts "\n\n\n\tdef fill_out_"+ page +"_form(b)\n\t\tb.goto(@@url+\"/"+ page +"\")"
                file.write "\n\t\to = "+@@page+".new("
                list.each do |input|
                                file.write  ":" + input.name + " => \"" + input.name + "\",  "
                end
                file.write " ) \n"               
                list.each do |input|
                                file.write  "\n\t\tb.text_field(:name, \"" + input.name + "\").set(o." + input.name + ")    " 
                end
                file.puts "\n\t\tb.driver.save_screenshot( @@testDir + '/fill_out_"+page+"_form.png' )"
                file.puts "\n\t\tb.button(:type, \"submit\").click "
                file.puts "\n\t\t#assert(b.text.include?(\"ThankYou\"))"  
                file.puts "\n\t\treturn o"
                file.puts "\n\tend"
end       
 
 
def setup_and_vars ( file)
                file.puts "\n\n\n\n\nclass TC_article_example < Test::Unit::TestCase"
                file.puts "\t@@testDir = 'TestResults/' +DateTime.now.strftime(\"%Y-%m-%d_%H-%M\")"
                file.puts "\t@@url = \"http://localhost:38519\""
                file.puts "\tdef setup"
                file.puts "\t\tif(!File.directory?(@@testDir))"
                file.puts "\t\t\td = Dir.mkdir(@@testDir)"
                file.puts "\t\tend\n\n"
                file.puts "\t\tputs 'results in  ' + @@testDir"
                file.puts "\tend"
                file.puts "\t"  
                file.puts "\tdef test_xxxxxx_form"  
                file.puts "\t\tb = Watir::Browser.new "  
                file.puts "\t\to = fill_out_xxxxxxxx_form(b) "  
                file.puts "\t\t#check_xxxxxx_table( b , o ) "  
                file.puts "\t\tb.close"  
                file.puts "\tend" 
end
 
 
File.open('TemplateOutput.rb', 'w') do |file|
                myInputs = b.body(:class => "").inputs
                build_input_class(file, myInputs) 
                setup_and_vars(file )
                build_fill_out_form(file, myInputs)
end 
 
 
 
=begin
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
 
=end
 
 
=begin
class Person 
  attr_accessor :name, :city , :state
end
=end    
 
class String
  def underscore
    self.gsub(/::/, '/').
    gsub(/([A-Z]+)([A-Z][a-z])/,'\1_\2').
    gsub(/([a-z\d])([A-Z])/,'\1_\2').
    tr("-", "_").
    downcase
  end
end                       
 
 
 
 